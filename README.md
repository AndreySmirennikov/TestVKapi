# TestVK
Приложение тестирует api VK

В качестве примера тестируется метод auth.signup (https://vk.com/dev/auth.signup)

Для запуска приложения достаточно воспользоваться батником run.bat в корне проекта(я считаю, что для данного кейса это наиболе удобный вариант предачи параметров вызова api ).

В батнике мы передаем параметры вызова api, причем первый параметр это название файла отчета(report) затем название самого api, а потом его параметры(названия и их значения) через пробел. Соответсвенно поменяв названия api и перечислив его парамтры(и их значения) через пробел можно вызвать другое api VK.

Если не менять название файла отчета тчета, то соотвественно все результаты тестирования будут записаны в один файл в директории reports. Если использовать разные название файлов отчетов, передоваемый в качестве первого аргумента из командной строки, то соотвественно под каждое название будет формироваться новый отчет.

На данный момент мне кажеться, что для такой крошечной програмки нет смысла выносить все по классам и и во всю награмождать ООП. Так же и с обработкой JSON. Так как нет необходимости(пока что) обрабатывать JSON, то соответсвенно обработки и нет. 
