namespace GymWorkouts.Workout
{
    internal class Breast
    {
        Dictionary<string, string> _breastTraning = new Dictionary<string, string>();

        public Dictionary<string, string> TraningProgramm(int numberOfTraining)
        {
            if (numberOfTraining == 1)
            {
                _breastTraning.Add("Жим на наклонe", "80Кг, 4*10");
                _breastTraning.Add("Разводки на ровной", "20Кг, 3*10");
                _breastTraning.Add("Брусья", "160, 4*12");
                _breastTraning.Add("Трицепс в тренажере", "70, 3*12");
                _breastTraning.Add("Разгибание на трицепс в кроссовере в наклоне", "20, 4*12");
                _breastTraning.Add("Пресс", "подьем ног лежа + прямые скручивания");
                return _breastTraning;
            }
            else
            {
                _breastTraning.Add("Жим на ровной", "95КГ, 3*12");
                _breastTraning.Add("Разводки в кроссовере на наклонной", "40, 4*12");
                _breastTraning.Add("Бабочка", "100, 3*15");
                _breastTraning.Add("Трицепс за голову", "15КГ, 4*12");
                _breastTraning.Add("Разгибание на трицепс в кроссовере с канатом", "80, 4*15");
                _breastTraning.Add("Пресс", "подьем ног лежа + прямые скручивания");
                return _breastTraning;
            }
        }
    }
}
