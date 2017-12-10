using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackwardChainingMVVM.Infrastructure
{
    public class GridViewData
    {
        public GridViewData(int Step, string Conclusion)
        {
            this.Step = Step;
            this.Conclusion = Conclusion;
        }

        public int Step { get; set; }

        public string Conclusion { get; set; }
    }
}
