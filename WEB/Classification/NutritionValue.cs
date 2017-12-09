using BayesSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WEB.Interfaces;

namespace WEB.Classification
{
    public class NutritionValue : Category
    {
        public override List<string> Categories { get; set; } = new List<string>
        {
            "Riebalai", "Angliavandeniai", "Baltymai",
        };

        public NutritionValue(IUserAccountDbContext context) : base(context) { }

        public override void Train()
        {
            List<string> fats = new List<string>
            {
                "Kiaušiniai OPTIMA LINIJA (L, rudi)",
                "Bulvių traškučiai ESTRELLA grietinės ir svogūnų sk.",
                "Bulvių traškučiai (sūrio sk) \"TAFFEL\"",
                "Pirmo spaudimo rapsų aliejus FLORIOL",
                "Skrudinti žemės riešutai JĖGA su medumi",
            };

            List<string> carbohydrates = new List<string>
            {
                "SPAGHETTI RISTORANTE Nr. 8",
                "Gazuotas kolos ir citrinų sk. gaivusis gėrimas COCA COL",
                "Bulvių traškučiai ESTRELLA grietinės ir svogūnų sk.",
                "Bulvių traškučiai (sūrio sk) \"TAFFEL\"",
                "Dribsniai SKANĒJA su vaisiais ir uogomis",
                "Dribsniai SKANĒJA su egzotiškais vaisiais",
                "Marinuoti česnakai \"Santa Maria\"",
                "AUKSINIAI plikyti ryžiai GALINTA (4 x 100 g)",
                "Kakavinės kriauklelės DINO",
                "Javainių batonėlis CHALLENGER su bananais",
                "Javainių batonėlis OKO su avietėmis ir mėlynėmis",
            };

            List<string> proteins = new List<string>
            {
                "Atšaldyta kiaulienos šoninė su kaulais",
                "Kiaušiniai OPTIMA LINIJA (L, rudi)",
                "Dribsniai SKANĒJA su vaisiais ir uogomis",
                "Dribsniai SKANĒJA su egzotiškais vaisiais",
                "Skrudinti žemės riešutai JĖGA su medumi",
            };

            List<List<string>> all = new List<List<string>>
            {
                fats, carbohydrates, proteins
            };

            base.Train(all);
        }

        public override void CategorizeAll()
        {
            _context.purchasedItem.ToList()
                .ForEach(x =>
                {
                    var nutritionValue = Classifier.Classify(x.ItemName);
                    x.Contains = "";
                    for (int i = 0; i < nutritionValue.Count; i++)
                    {
                        if (nutritionValue.Values.ElementAt(i) >= 0.2)
                        {
                            if (!x.Contains.Equals(""))
                            {
                                x.Contains += "|";
                            }
                            x.Contains += nutritionValue.Keys.ElementAt(i);
                        }
                        else
                        {
                            break;
                        }
                    }
                });
            _context.SaveChanges();
        }
        public void CategorizeAllByCategories()
        {
            _context.purchasedItem.Where(x => x.Category == "Vaisiai" || x.Category == "Skanumynai").ToList()
                .ForEach(x => x.Contains = Categories[1]);

            _context.purchasedItem.Where(x => x.Category == "Kūno priežiūros priemonės").ToList()
                .ForEach(x => x.Contains = "");

            _context.purchasedItem.Where(x => x.Category == "Žuvis").ToList()
                .ForEach(x => x.Contains = Categories[0] + "|" + Categories[2]);

            _context.purchasedItem.Where(x => x.Category == "Pieno produktai").ToList()
                .ForEach(x => x.Contains = Categories[2]);

            _context.purchasedItem.Where(x => x.Category == "Duonos gaminiai").ToList()
                .ForEach(x => x.Contains = Categories[1] + "|" + Categories[2]);

            _context.SaveChanges();
        }
    }
}