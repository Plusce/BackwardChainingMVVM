using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackwardChainingMVVM.Model;

namespace BackwardChainingMVVM.Services
{
    public interface IBackwardChainingTemperamentService
    {
        List<string> MessagesList { get; set; }

        bool IsUserNeurotic (UserTemperament userTemperament);

        bool IsUserIntrovert (UserTemperament userTemperament);

        bool IsUserBalanced (UserTemperament userTemperament);

        bool IsUserExtrovert (UserTemperament userTemperament);

        bool IsUserMixed(UserTemperament userTemperament);
    }
}
