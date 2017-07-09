using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSeriesApp.Models
{
    public class CategoryNode : IEnumerable<CategoryNode>
    {
        private readonly Dictionary<string, CategoryNode> children =
                                            new Dictionary<string, CategoryNode>();

        public string ID { get; set; }
        public CategoryNode Parent { get; private set; }

        public List<TimeSeries> TimeSeries { get; set; } 

        public CategoryNode(string id)
        {
            this.ID = id;
        }

        public CategoryNode GetChild(string id)
        {
            return this.children[id];
        }

        public void Add(CategoryNode item)
        {
            if (item.Parent != null)
            {
                item.Parent.children.Remove(item.ID);
            }

            item.Parent = this;
            this.children.Add(item.ID, item);
        }

        public IEnumerator<CategoryNode> GetEnumerator()
        {
            return this.children.Values.GetEnumerator();
        }


        IEnumerator<CategoryNode> IEnumerable<CategoryNode>.GetEnumerator()
        {
            return this.children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get { return this.children.Count; }
        }
    }
}