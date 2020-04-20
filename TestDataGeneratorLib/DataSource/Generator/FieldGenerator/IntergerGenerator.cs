using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public class IntergerGenerator : IFieldGenerator
    {
        private int startValue;

        private int step;

        public IntergerGenerator(int startValue = 1, int step = 1)
        {
            this.startValue = startValue;
            this.step = step;
        }

        public object NextValue(DataColumn column, int rowIndex, DataRow previousRow)
        {
            // TODO
            //int prevValue = (int?)previousRow?[column] ?? startValue - step;
            //return prevValue + step;
            return rowIndex;
        }
    }
}
