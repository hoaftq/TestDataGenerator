using System;
using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public class DateTimeGenerator : IFieldGenerator
    {
        private DateTime startValue;

        private TimeSpan step;

        public DateTimeGenerator()
        {
            startValue = DateTime.Now;
            step = TimeSpan.FromDays(1);
        }

        public DateTimeGenerator(DateTime startValue)
        {
            this.startValue = startValue;
            step = TimeSpan.FromDays(1);
        }

        public DateTimeGenerator(DateTime startValue, TimeSpan step)
        {
            this.startValue = startValue;
            this.step = step;
        }

        public object NextValue(DataColumn colum, int rowIndex, DataRow previousRow)
        {
            var prevValue = (DateTime?)previousRow?[colum] ?? startValue.Subtract(step);
            return prevValue.Add(step);
        }
    }
}
