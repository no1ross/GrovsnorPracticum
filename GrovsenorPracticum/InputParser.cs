using System;
using System.Collections.Generic;
using System.Linq;

namespace GrovsenorPracticum
{
    public class InputParser : IInputParser
    {
        private const string Error = "error";
        private const string MisingTimeOfDay = "You must enter time of day as 'morning' or 'night'";
        private const string MissingSelection = "You must enter a comma delimited list of dish types with at least one selection";
        private const string MultiItemFormat = "{0}(x{1})";

        public string ParseInput(string inputString)
        {
            if (inputString == null)
                return Error;

            var inputs = inputString.Split(',');
            if (inputs.Length < 2)
                return MissingSelection;

            TimeOfDay timeOfDay;
            if (!Enum.TryParse(inputs[0], true, out timeOfDay))
                return MisingTimeOfDay;

            var dishItems = new List<string>();

            if (timeOfDay == TimeOfDay.Morning)
            {
                PopulateDishes<MorningTypes>(inputs, dishItems);
            }
            else
            {
                PopulateDishes<NightTypes>(inputs, dishItems);
            }

            var itemCounts = dishItems.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var results = itemCounts.Select(item => item.Value > 1 ? string.Format(MultiItemFormat, item.Key, item.Value) : item.Key).ToList();

            return string.Join(", ", results);
        }

        private static void PopulateDishes<TType>(IEnumerable<string> parameters, ICollection<string> dishItems) where TType : struct
        {
            var dishes = parameters.OrderBy(x => x).ToArray();
            for (var i = 0; i < dishes.Length - 1; i++)
            {
                int paramValue;
                if (VerifyParameter(dishItems, dishes, i, out paramValue)) break;

                if (VerifyDishTypes(dishItems, dishes, i, paramValue)) break;

                TType enumType;
                if (VerifyEnumValue(dishItems, dishes, i, paramValue, out enumType)) break;

                if (AddDuplicates(dishItems, enumType)) break;
            }
        }

        private static bool VerifyParameter(ICollection<string> dishItems, IList<string> dishes, int i, out int paramValue)
        {
            if (int.TryParse(dishes[i], out paramValue)) return false;
            dishItems.Add(Error);
            return true;
        }

        private static bool VerifyDishTypes(ICollection<string> dishItems, IList<string> dishes, int i, int paramValue)
        {
            DishTypes dishType;
            if (Enum.TryParse(dishes[i], true, out dishType)
                && Enum.IsDefined(typeof(DishTypes), paramValue))
                return false;
            dishItems.Add(Error);
            return true;
        }

        private static bool VerifyEnumValue<TType>(ICollection<string> dishItems, string[] dishes, int i, int paramValue,
            out TType enumType) where TType : struct
        {
            if (Enum.TryParse(dishes[i], true, out enumType)
                && Enum.IsDefined(typeof(TType), paramValue))
                return false;
            dishItems.Add(Error);
            return true;
        }

        private static bool AddDuplicates<TType>(ICollection<string> dishItems, TType enumType) where TType : struct
        {
            if (dishItems.Contains(enumType.ToString().ToLower()))
            {
                if (AddDuplicateItem(dishItems, enumType)) return true;
            }
            else
            {
                dishItems.Add(enumType.ToString().ToLower());
            }
            return false;
        }

        private static bool AddDuplicateItem<TType>(ICollection<string> dishItems, TType enumType) 
            where TType : struct
        {
            if (String.Equals(enumType.ToString(), MorningTypes.Coffee.ToString(), StringComparison.CurrentCultureIgnoreCase)
                || String.Equals(enumType.ToString(), NightTypes.Potato.ToString(), StringComparison.CurrentCultureIgnoreCase))
                dishItems.Add(enumType.ToString().ToLower());
            else
            {
                dishItems.Add(Error);
                return true;
            }
            return false;
        }
    }
}
