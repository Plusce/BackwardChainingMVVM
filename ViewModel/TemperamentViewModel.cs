using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackwardChainingMVVM.Infrastructure;
using BackwardChainingMVVM.Model;
using BackwardChainingMVVM.Services;

namespace BackwardChainingMVVM.ViewModel
{
    public class TemperamentViewModel : ITemperamentViewModel
    {
        #region Ctor

        public TemperamentViewModel(IBackwardChainingTemperamentService service, UserTemperament userTemperament)
        {
            _service = service;
            _userTemperament = userTemperament;
        }

        #endregion

        #region Fields and properties

        private IBackwardChainingTemperamentService _service;
        private UserTemperament _userTemperament;

        public UserTemperament Model
        {
            get
            {
                return _userTemperament;
            }
            set
            {
                _userTemperament = value;
            }
        }

        public IBackwardChainingTemperamentService Service
        {
            get
            {
                return _service;
            }
        }

        #endregion

        #region Methods

        public bool IsHypothesisTrue(string hypothesis, UserTemperament model)
        {
            bool isHypothesisTrue;
            TemperamentEnum enumValue;

            if (!Enum.TryParse(hypothesis, out enumValue))
            {
                MessageBox.Show(Properties.Resources.HypothesisIsNotSelected, Properties.Resources.Error
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            switch (enumValue)
            {
                case TemperamentEnum.Neurotic:
                    isHypothesisTrue = Service.IsUserNeurotic(model);
                    break;
                case TemperamentEnum.Balanced:
                    isHypothesisTrue = Service.IsUserBalanced(model);
                    break;
                case TemperamentEnum.Extravert:
                    isHypothesisTrue = Service.IsUserExtrovert(model);
                    break;
                case TemperamentEnum.Introvert:
                    isHypothesisTrue = Service.IsUserIntrovert(model);
                    break;
                case TemperamentEnum.Mixed:
                    isHypothesisTrue = Service.IsUserMixed(model);
                    break;
                default:
                    isHypothesisTrue = false;
                    break;
            }

            return isHypothesisTrue;
        }

        #endregion
    }
}
