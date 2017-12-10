using BayesSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WEB.Interfaces;

namespace WEB.Classification
{
    public class MainCategory : Category
    {

        public override List<string> Categories { get; set; } = new List<string>
        {
            "Mėsa", "Užkandžiai", "Kūno priežiūros priemonės", "Pieno produktai", "Gėrimai", "Vaisiai",
            "Daržovės", "Skanumynai", "Duonos gaminiai", "Kruopos", "Žuvis", "Kita"
        };

        public MainCategory(IUserAccountDbContext context) : base(context) { }

        public override void Train()
        {
            List<string> meat = new List<string>
            {
                "Atšaldyta kiaulienos šoninė su kaulais"
            };

            List<string> snacks = new List<string>
            {
                "Bulvių traškučiai ESTRELLA grietinės ir svogūnų sk.",
                "Javainių batonėlis CHALLENGER su bananais",
                "Javainių batonėlis OKO su avietėmis ir mėlynėmis",
                "Bulvių traškučiai (sūrio sk) \"TAFFEL\""
            };

            List<string> selfcare = new List<string>
            {
                "Plaukų lakas TAFT ULTIMATE",
                "Tualetinis popierius \"Zeva Deluxe Pure White\"",
                "Ekologiška balinamoji dantų pasta ECODENTA (PAPAYA)",
                "CENTO SKYSTAS RANKŲ MUILA",
                "VYRIŠKAS DEZODORANTAS \"G"
            };
            
            List<string> dairy = new List<string>
            {
                "Jogurtas SMILGA su braškių ir mėlynių gabaliuk., 3,3%",
                "Natūralus Rokiškio NAMINIS pienas, 3,5% rieb.",
                "DVARO kefyras, 3,2% rieb.",
                "Jogurtas JO su persikais ir abrikosais, 2,52 rieb.",
                "Rokiškio NAMINIS kefyras, 2,5% rieb."
            };

            List<string> drinks = new List<string>
            {
                "Gazuotas kolos ir citrinų sk. gaivusis gėrimas COCA COL",
                "Negazuotas gėrimas VITAMIN PERFORMANCE MENTAL su vitami",
                "Švelniai gazuotas stalo vanduo NEPTŪNAS LEMON",
                "ŠVYTURIO gintarinis alus",
                "Alus 4,6% \"Tuborg Green\"",
                "Raud.vynuogių. aroniju ir mėlynių gėrimas\"Elmenhorster",
                "Persikų nektaras, 50% \"Elmenhorster\"",
                "Alus, 5,1% \"WOLTERS PILSENER\""
            };

            List<string> fruits = new List<string>
            {
                "Obuoliai CHAMPION (fasuoti, nuo 55 mm)",
                "Maroko mandarinai (3-4 d.)",
                "Didieji greipfrutai POMELO",
                "Citrinos, 4 d. \"Verna\""
            };

            List<string> vegetables = new List<string>
            {
                "Svogūnų laiškai (fasuoti) LINKĖJIMAI IŠ KAIMO",
                "Marinuoti česnakai \"Santa Maria\"",
                "Kons.pomidorai savo sultyse \"Auksinis derlius\"",
                "Raudonos saldžiosios paprikos, 70-90 mm",
                "Raudonieji ridikėliai, fas."
            };

            List<string> sweetsAndPatisserie = new List<string>
            {
                "Bandelė su kakaviniu glaistu",
                "Pieninis šokoladas MILKA DAIM su migdolų karamelės",
                "Sviestinis prancūziškas kruasanas su kumpiu ir sūriu",
                "Spurga DONUTS su kakaviniu glaistu (atitirpinta)",
                "Itališka apkepelė su šonine in Besamelio padažu",
                "Kakavos ir lazdynų riešutų kremas MELTEZ ROYALLER",
                "Saldainiai (15 vnt.) \"Raffaello\""
            };

            List<string> bread = new List<string>
            {
                "Raikytas MALŪNO batonas",
                "Raikytas SOSTINĖS batonas"
            };

            List<string> crops = new List<string>
            {
                "AUKSINIAI plikyti ryžiai GALINTA (4 x 100 g)"
            };

            List<string> fish = new List<string>
            {
                "Šald.glaz.argentininės jūrinės lydekos (be galvų ir",
                "Šaldyta aliaskinių rudagalvių menkių filė be odos"
            };

            List<string> other = new List<string>
            {
                "Kiaušiniai OPTIMA LINIJA (L, rudi)",
                "Avižinė košė su avietėmis 40 g",
                "Skrudinti žemės riešutai JĖGA su medumi",
                "SPAGHETTI RISTORANTE Nr. 8",
                "Kakavinės kriauklelės DINO",
                "Dribsniai SKANĒJA su vaisiais ir uogomis",
                "Pirmo spaudimo rapsų aliejus FLORIOL",
                "Dribsniai SKANĒJA su egzotiškais vaisiais",
                "Atvirukas (dvigubas, celof. įmautė)",
                "Pievagrybiai"
            };            

            List<List<string>> all = new List<List<string>>
            {
                meat, snacks, selfcare, dairy, drinks, fruits, vegetables, sweetsAndPatisserie,
                bread, crops, fish, other
            };

            base.Train(all);
        }

        public override void CategorizeAll()
        {
            _context.purchasedItem.ToList()
                .ForEach(x =>
                {
                    var category = Classifier.Classify(x.ItemName).Keys;
                    if (category.Count == 0)
                    {
                        x.Category = "Kita";
                    }
                    else
                    {
                        x.Category = category.First();
                    }
                });
            _context.SaveChanges();
        }
    }
}