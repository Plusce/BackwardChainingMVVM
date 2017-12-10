using BackwardChainingMVVM.Model;
using BackwardChainingMVVM.Services;

namespace BackwardChainingMVVM.ViewModel
{
    public interface ITemperamentViewModel
    {
        UserTemperament Model { get; set; }

        IBackwardChainingTemperamentService Service { get; }

        bool IsHypothesisTrue(string hypothesis, UserTemperament model);
    }
}