using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lunchbox.api.Model
{
    public class Plan
    {
        public int id;
        public string name;

        public double price;
        public string description;
        public int meal_type_id;
        public int duration_id;
    }
}
