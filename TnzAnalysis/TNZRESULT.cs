using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnzAnalysis
{
    public class TNZRESULT
    {
        //Error Codes
        public static readonly int TNZD_ERROR_OK = Convert.ToInt32("0x00000000", 16);                    //типа все ОК
        public static readonly int TNZD_ERROR_FATAL = Convert.ToInt32("0xFFFFFFFF", 16);                //Возвращается в случае невозможности продолжения работы библиотеки.
        public static readonly int TNZD_ERROR_INVALIDPARAM = Convert.ToInt32("0x80000001", 16);               //вызов функции с неверным параметром
        public static readonly int TNZD_ERROR_VERYLONGPARAM = Convert.ToInt32("0x80000002", 16);               //не хватает буфера для пользовательского параметра БД

        public static readonly int TNZD_ERROR_HOST_NOTFOUND = Convert.ToInt32("0x80010001", 16);               //хост не установлен в системе
        public static readonly int TNZD_ERROR_HOST_INVALID = Convert.ToInt32("0x80010002", 16);               //фатальная ошибка работы с хостом. Прекратить работу.
        public static readonly int TNZD_ERROR_HOST_LOCKED = Convert.ToInt32("0x80010011", 16);               //хост зарезервирован другим процессом
        public static readonly int TNZD_ERROR_HOST_NOTINITIALIZED = Convert.ToInt32("0x80010012", 16);               //хост присутствует в системе, но не подключён к dll
        public static readonly int TNZD_ERROR_HOST_NOT_READY = Convert.ToInt32("0x80010111", 16);               //хост работает в режиме непрерывного приёма данных.

        public static readonly int TNZD_ERROR_TENZO_FAULTS = Convert.ToInt32("0x80011000", 16);               //ошибка работы тензосистемы, лучше перезагрузить её
        public static readonly int TNZD_ERROR_HARDWARE_STOP = Convert.ToInt32("0x80011001", 16);               //система была запущена на измерение и остановилась по обрыву связи.

        //Код выдаётся только один раз после произошедшего.
        public static readonly int TNZD_ERROR_DB_ERROR = Convert.ToInt32("0x80020000", 16);               //ошибка работы с БД,  сведения в файле заголовка противоречивы или не адекватны реальной БД
        public static readonly int TNZD_ERROR_DB_INVALIDHANDLE = Convert.ToInt32("0x80020001", 16);               //переданный хэндл-указатель БД не существует
        public static readonly int TNZD_DB_SHARING_VIOLATION = Convert.ToInt32("0x80020002", 16);               //нет доступа на удаление БД
        public static readonly int TNZD_DB_MOVE_ERROR = Convert.ToInt32("0x80020003", 16);               //ошибка перемещения БД при том, что доступ на удаление есть. БД испорчена.

        public static readonly int TNZD_ERROR_INVALIDSETTINGS = Convert.ToInt32("0x8000000F", 16);               //несоответствие настроек хоста требованиям пользователя...
        public static readonly int TNZD_ERROR_INVALIDTHREAD = Convert.ToInt32("0x80000010", 16);
    }
}
