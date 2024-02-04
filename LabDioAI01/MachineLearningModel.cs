namespace LabDioAI01
{
    public class MachineLearningModel
    {
        public Input_Data input_data { get; set; }
    }

    public class Datum
    {
        public string Data { get; set; }
        public string Condicoes_climaticas { get; set; }
    }

    public class Input_Data
    {
        public List<string> columns { get; set; }
        public List<int> index { get; set; }
        public List<Datum> data { get; set; }
    }

}
