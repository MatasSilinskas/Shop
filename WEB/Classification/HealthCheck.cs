using BayesSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WEB.Interfaces;

namespace WEB.Classification
{
    public class HealthCheck : Category
    {
        public override List<string> Categories { get; set; } = new List<string>
        {
            "Nesveikas", "Nevalgomas"
        };

        public HealthCheck(IUserAccountDbContext context) : base(context) { }

        public override void Train()
        {
            List<string> notHealthy = new List<string>
            {
                "Gazuotas kolos ir citrinų sk. gaivusis gėrimas COCA COL",
                "ŠVYTURIO gintarinis alus",
                "Alus 4,6% \"Tuborg Green\"",
                "Alus, 5,1% \"WOLTERS PILSENER\""
            };

            List<string> notEatable = new List<string>
            {
                "Atvirukas (dvigubas, celof. įmautė)",
            };

            List<List<string>> all = new List<List<string>>
            {
                notHealthy, notEatable
            };

            base.Train(all);
        }

        public override void CategorizeAll()
        {
            _context.purchasedItem.ToList()
                .ForEach(x =>
                {
                    var category = Classifier.Classify(x.ItemName);
                    if (category.Count == 0)
                    {
                        x.IsHealthy = true;
                    }
                    else
                    {
                        x.IsHealthy = false;
                    }
                });
            _context.SaveChanges();
        }

        public void CategorizeAllByCategories()
        {
            _context.purchasedItem.Where(x => x.Category == "Užkandžiai").ToList()
                .ForEach(x => x.IsHealthy = false);

            _context.purchasedItem.Where(x => x.Category == "Kūno priežiūros priemonės").ToList()
                .ForEach(x => x.IsHealthy = null);

            _context.SaveChanges();
        }
    }
}