using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackwardChainingMVVM.Model;

namespace BackwardChainingMVVM.Services
{
    internal sealed class BackwardChainingTemperamentService : IBackwardChainingTemperamentService
    {
        public List<string> MessagesList { get; set; } = new List<string>();

        public bool IsUserBalanced(UserTemperament userTemperament)
        {
           if(IsUserPhlegmatic(userTemperament.IsPassive, userTemperament.IsConsiderable, userTemperament.IsCareful)
                && IsUserSanguine(userTemperament.IsSociable, userTemperament.IsSensitive, userTemperament.IsLeadership))
           {
               MessagesList.Add(Properties.Resources.UserIsBalanced);
                return true;
           }

           MessagesList.Add(Properties.Resources.UserIsNotBalanced);
           return false;
        }

        public bool IsUserExtrovert(UserTemperament userTemperament)
        {
            if (IsUserSanguine(userTemperament.IsSociable, userTemperament.IsSensitive, userTemperament.IsLeadership)
                && IsUserSpitfire(userTemperament.IsAgressive, userTemperament.IsUnstable, userTemperament.IsIrritable))
            {
                MessagesList.Add(Properties.Resources.UserIsExtrovert);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotExtrovert);
            return false;
        }

        public bool IsUserIntrovert(UserTemperament userTemperament)
        {
            if (IsUserPhlegmatic(userTemperament.IsPassive, userTemperament.IsConsiderable, userTemperament.IsCareful)
                && IsUserMelancholic(userTemperament.IsApathetic, userTemperament.IsPessimistic, userTemperament.IsUnsociable))
            {
                MessagesList.Add(Properties.Resources.UserIsIntrovert);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotIntrovert);
            return false;
        }

        public bool IsUserNeurotic(UserTemperament userTemperament)
        {
            if (IsUserSpitfire(userTemperament.IsAgressive, userTemperament.IsUnstable, userTemperament.IsIrritable)
                && IsUserMelancholic(userTemperament.IsApathetic, userTemperament.IsPessimistic, userTemperament.IsUnsociable))
            {
                MessagesList.Add(Properties.Resources.UserIsNeurotic);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotNeurotic);
            return true;
        }

        public bool IsUserMixed(UserTemperament userTemperament)
        {
            if (IsUserBalanced(userTemperament) && IsUserExtrovert(userTemperament) && IsUserIntrovert(userTemperament))
            {
                MessagesList.Add(Properties.Resources.UserIsMixed);
                return true;
            }

            else if(IsUserNeurotic(userTemperament) && IsUserExtrovert(userTemperament) && IsUserIntrovert(userTemperament))
            {
                MessagesList.Add(Properties.Resources.UserIsMixed);
                return true;
            }

            else if(IsUserBalanced(userTemperament) && IsUserNeurotic(userTemperament) && IsUserIntrovert(userTemperament))
            {
                MessagesList.Add(Properties.Resources.UserIsMixed);
                return true;
            }

            else if (IsUserBalanced(userTemperament) && IsUserExtrovert(userTemperament) && IsUserNeurotic(userTemperament))
            {
                MessagesList.Add(Properties.Resources.UserIsMixed);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotMixed);
            return false;
        }

        private bool IsUserMelancholic(bool IsUserApathetic, bool IsUserPessimistic, bool IsUserUnsociable)
        {
            if ((IsUserApathetic && IsUserPessimistic) || (IsUserApathetic && IsUserUnsociable) || (IsUserPessimistic && IsUserUnsociable))
            {
                MessagesList.Add(Properties.Resources.UserIsMelancholic);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotMelancholic);
            return false;
        }

        private bool IsUserPhlegmatic(bool IsUserPassive, bool IsUserConsiderable, bool IsUserCareful)
        {
            if ((IsUserPassive && IsUserConsiderable) || (IsUserConsiderable && IsUserCareful) || (IsUserPassive && IsUserCareful))
            {
                MessagesList.Add(Properties.Resources.UserIsPhlegmatic);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotPhlegmatic);
            return false;
        }

        private bool IsUserSanguine(bool IsUserSociable, bool IsUserSensitive, bool IsUserLeadership)
        {
            if ((IsUserSociable && IsUserSensitive) || (IsUserSensitive && IsUserLeadership) || (IsUserSociable && IsUserLeadership))
            {
                MessagesList.Add(Properties.Resources.UserIsSanguine);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotSanguine);
            return false;
        }

        private bool IsUserSpitfire(bool IsUserAgressive, bool IsUserUnstable, bool IsUserIrritable)
        {
            if ((IsUserAgressive && IsUserUnstable) || (IsUserUnstable && IsUserIrritable) || (IsUserAgressive && IsUserIrritable))
            {
                MessagesList.Add(Properties.Resources.UserIsSpitfire);
                return true;
            }

            MessagesList.Add(Properties.Resources.UserIsNotSpitfire);
            return false;
        }
    }
}
