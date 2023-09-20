namespace GymWorkouts.Workout
{
    internal class Legs
    {
        Dictionary<string, string> _legsTraning = new Dictionary<string, string>();

        public Dictionary<string, string> TraningProgramm(int numberOfTraining)
        {
            if (numberOfTraining == 1)
            {
                _legsTraning.Add("Жим платформы", "180, 4*15");
                _legsTraning.Add("Сгибание ног лежа", "150, 4*15");
                _legsTraning.Add("Икры сидя", "40Кг, 4*15 + добить 10р");
                _legsTraning.Add("Жим гантелей на плечи", "30, 4*10");
                _legsTraning.Add("Протяжка штанги", "40Кг, 4*12");
                _legsTraning.Add("Канат на заднюю дельту", "75, 4*15");
                _legsTraning.Add("Пресс", "мячи");
                return _legsTraning;
            }
            else
            {
                _legsTraning.Add("Жим платформы", "180, 4*15");
                _legsTraning.Add("Сгибание сидя", "160, 4*15");
                _legsTraning.Add("Икры стоя", "130, 4*15 + добивание 10");
                _legsTraning.Add("Жим штанги стоя", "50Кг, 4*10");
                _legsTraning.Add("Разводки + вперед", "7кг, 4*10");
                _legsTraning.Add("Задняя в тренажере", "40кг, 4*12");
                _legsTraning.Add("Пресс", "мячи");
                return _legsTraning;
            }
        }
    }
}
