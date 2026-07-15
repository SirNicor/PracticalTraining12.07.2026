using System.Text.RegularExpressions;

namespace WebApplication1.Helpers;

public static class Validators
{
    public static (bool IsValid, string? Error) ValidateClassroomNumber(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return (false, "Номер аудитории обязателен для заполнения.");

        var trimmed = number.Trim();

        var pattern = @"^\d{1,4}([-\s]?[А-Яа-яA-Za-z])?$";
        if (!Regex.IsMatch(trimmed, pattern))
            return (false, "Некорректный формат номера. Примеры: 301, 301а, 12-Б, 404 A.");

        if (trimmed.Length > 10)
            return (false, "Номер аудитории слишком длинный.");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateTeacherFio(string? fio)
    {
        if (string.IsNullOrWhiteSpace(fio))
            return (false, "ФИО преподавателя обязательно для заполнения.");

        var trimmed = fio.Trim();

        var parts = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2)
            return (false, "ФИО должно содержать минимум фамилию и имя (например: Иванов Иван).");

        if (parts.Length > 3)
            return (false, "ФИО должно содержать не более трёх слов (Фамилия Имя Отчество).");

        var wordPattern = @"^[А-ЯЁA-Z][А-ЯЁа-яёa-z\-]*$";
        foreach (var part in parts)
        {
            if (!Regex.IsMatch(part, wordPattern))
                return (false, $"Слово '{part}' должно начинаться с заглавной буквы и содержать только буквы.");
        }

        if (trimmed.Length > 100)
            return (false, "ФИО слишком длинное (максимум 100 символов).");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateGroupName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Название группы обязательно для заполнения.");

        var trimmed = name.Trim();

        if (trimmed.Length < 2)
            return (false, "Название группы слишком короткое (минимум 2 символа).");

        if (trimmed.Length > 20)
            return (false, "Название группы слишком длинное (максимум 20 символов).");

        var pattern = @"^[А-ЯЁа-яёA-Za-z0-9\s\-]+$";
        if (!Regex.IsMatch(trimmed, pattern))
            return (false, "Название может содержать только буквы, цифры, дефис и пробелы.");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateSubjectName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Название предмета обязательно для заполнения.");

        var trimmed = name.Trim();

        if (trimmed.Length < 2)
            return (false, "Название предмета слишком короткое (минимум 2 символа).");

        if (trimmed.Length > 100)
            return (false, "Название предмета слишком длинное (максимум 100 символов).");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateNumberOfWeek(int? numberOfWeek)
    {
        if (!numberOfWeek.HasValue)
            return (false, "Номер недели обязателен для заполнения.");

        if (numberOfWeek.Value < 1 || numberOfWeek.Value > 4)
            return (false, "Номер недели должен быть в диапазоне от 1 до 4.");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateDayOfWeek(int? dayOfWeek)
    {
        if (!dayOfWeek.HasValue)
            return (false, "День недели обязателен для выбора.");

        if (dayOfWeek.Value < 1 || dayOfWeek.Value > 6)
            return (false, "День недели должен быть в диапазоне от 1 (Пн) до 6 (Сб).");

        return (true, null);
    }

    public static (bool IsValid, string? Error) ValidateLessonTime(DateTime? time)
    {
        if (!time.HasValue)
            return (false, "Время начала занятия обязательно.");

        if (time.Value.TimeOfDay < new TimeSpan(8, 0, 0) || time.Value.TimeOfDay > new TimeSpan(21, 0, 0))
            return (false, "Время занятия должно быть в диапазоне с 08:00 до 21:00.");

        return (true, null);
    }
}