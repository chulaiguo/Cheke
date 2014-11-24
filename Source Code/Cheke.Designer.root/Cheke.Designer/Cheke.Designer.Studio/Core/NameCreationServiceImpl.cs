using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Cheke.Designer.Studio.Core
{
    public class NameCreationServiceImpl : INameCreationService
    {
        string INameCreationService.CreateName(IContainer container, Type type)
        {
            ComponentCollection componentList = container.Components;
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            int count = 0;

            foreach (Component item in componentList)
            {
                if (item.GetType() != type)
                    continue;
                   
                count++;

                string name = item.Site.Name;
                if (name.StartsWith(type.Name))
                {
                    int value;
                    if(int.TryParse(name.Substring(type.Name.Length), out value))
                    {
                        if (value < min)
                            min = value;

                        if (value > max)
                            max = value;
                    }
                }
            }


            if (count == 0)
            {
                return type.Name + 1;
            }
            if (min > 1)
            {
                return type.Name + (min - 1);
            }

            return type.Name + (max + 1);
        }

        bool INameCreationService.IsValidName(string name)
        {
            return true;
        }

        void INameCreationService.ValidateName(string name)
        {
            return;
        }
    }
}