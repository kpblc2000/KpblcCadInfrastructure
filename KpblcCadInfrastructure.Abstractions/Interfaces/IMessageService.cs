using System;

namespace KpblcCadInfrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Сервис сообщений
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Сообщение в консоль
        /// </summary>
        /// <param name="Message">Выводимое сообщение, без символов переноса строки</param>
        /// <param name="CallerName">Вызывающий метод</param>
        void ConsoleMessage(string Message, string CallerName = null);
        /// <summary>
        /// Информационное сообщение
        /// </summary>
        /// <param name="Message">Выводимое сообщение, без символов переноса строки</param>
        /// <param name="CallerName">Вызывающий метод</param>
        void InfoMessage(string Message, string CallerName = null);
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="Message">Выводимое сообщение, без символов переноса строки</param>
        /// <param name="CallerName">Вызывающий метод</param>
        void ErrorMessage(string Message, string CallerName = null);
        /// <summary>
        /// Сообщение об исключении
        /// </summary>
        /// <param name="Ex">Сгенерированное сообщение об ошибке</param>
        /// <param name="CallerName">Вызывающий метод</param>
        void ExceptionMessage(Exception Ex, string CallerName = null);
    }
}