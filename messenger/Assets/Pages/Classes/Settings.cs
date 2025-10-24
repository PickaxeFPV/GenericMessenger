using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.IsolatedStorage;

namespace messenger.Assets.Pages.Classes
{
    class Settings
    {
        public static IsolatedStorageSettings localSettings
                    = IsolatedStorageSettings.ApplicationSettings; // создаём изолированное пространство

        public static void SetSetting(string key, object value)
        {
            localSettings[key] = value; //готовит "ячейку" для переменной
            localSettings.Save(); //сохраняет переменную в эту "ячейку"
        }

        public static object GetSetting(string key)
        {
            try // проверяет наличие данных в "ячейке"
            {   // значение найдено? Выводим данные "ячейки"
                return localSettings.Contains(key) ? localSettings[key] : null;
            }
            catch (Exception e) // Значение не найдено.
            {
                return null; // ничего не возвращаем
            }
        }

        // Проверяем вход
        public static bool IsSetupPass
        {
            get
            {
                return GetSetting("IsSetupPass") as bool? ?? false;
            }
            set { SetSetting("IsSetupPass", value); }
        }

        public static bool StickersE
        {
            get
            {
                return GetSetting("StickersE") as bool? ?? true;
            }
            set { SetSetting("StickersE", value); }
        }
    }
}
