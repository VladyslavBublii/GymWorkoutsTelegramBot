namespace GymWorkouts.Workout
{
    internal class Back
    {
        Dictionary<string, string> _backTraning = new Dictionary<string, string>();

        public Dictionary<string,string> TraningProgramm(int numberOfTraining)
        {
            if (numberOfTraining == 1) 
            { 
                _backTraning.Add("Тяга штанги в наклоне", "70Кг, 4*12");
                _backTraning.Add("Тяга вертикального блока", "120, 4*10 + дроп 8");
                _backTraning.Add("Тяга горизонтального блока с широкой рукояткой", "90, 4*10 + дроп 8");
                _backTraning.Add("Бицепс в скотте", "35,35,35,30 * 10");
                _backTraning.Add("Бицепс в диагональ", "10, 4*10");
                _backTraning.Add("Пресс", "в тренажере + поочередный подьем ног");
                return _backTraning;
            }
            else
            {
                _backTraning.Add("Турник", "180, 4*12");
                _backTraning.Add("Горизонт с обычной рукояткой", "100, 4*12 + дроп 8");
                _backTraning.Add("Через стороны", "80, 4*10");
                _backTraning.Add("Пуловер", "100, 4*12");
                _backTraning.Add("Подьем штанги на бицепс", "35,35,30,30 4*10");
                _backTraning.Add("Подьем гант сидя", "10 и 7, 4*10");
                _backTraning.Add("Пресс", "в трен + поочередный подьем ног");
                return _backTraning;
            }
        }
    }
}
