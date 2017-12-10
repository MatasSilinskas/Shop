using BayesSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WEB.Interfaces;

namespace WEB.Classification
{
    public abstract class Category
    {
        public BayesSimpleTextClassifier Classifier { get; set; }

        public abstract List<string> Categories { get; set; }

        protected readonly IUserAccountDbContext _context;

        public Category(IUserAccountDbContext context)
        {
            _context = context;
            Classifier = new BayesSimpleTextClassifier();
        }

        protected void Train(List<List<string>> allCategories)
        {
            int i = 0;
            foreach (var item in allCategories)
            {
                foreach (var text in item)
                {
                    Classifier.Train(Categories[i], text);
                }
                i++;
            }
        }

        public abstract void CategorizeAll();
        public abstract void Train();
    }
}