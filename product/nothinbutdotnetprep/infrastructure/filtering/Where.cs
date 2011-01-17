using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static ??? has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {

        }
//        public static Func<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
//        {
//            return property_accessor;
//        }
    }
}