1. **Задаване на Environment Variables:**
   - За Windows:
     - Отворете Command Prompt и въведете следните команди, като замените `<your_connection_string>` и `<your_openai_key>` с вашите стойности:
       ```
       setx CONNECTION_STRING "<your_connection_string>"
       setx OPENAI_KEY "<your_openai_key>"
       ```
     - Това ще зададе променливите за цялата система. За да се отразят промените, може да се наложи да рестартирате IDE или компютъра.

   - За macOS/Linux:
     - Отворете терминала и добавете следните редове към файла `.bashrc`, `.bash_profile` или `.zshrc`, отново като замените стойностите:
       ```
       export CONNECTION_STRING="<your_connection_string>"
       export OPENAI_KEY="<your_openai_key>"
       ```
     - За да активирате промените, изпълнете `source ~/.bashrc` (или съответния файл за вашата обвивка).

2. **Разархивиране на архив:**
   - Ако използвате Windows, може да използвате инструменти като WinRAR или 7-Zip. Десен клик върху файла и изберете `Extract Here` или `Extract to <folder_name>`.
   - На macOS/Linux, може да използвате терминалната команда:
     ```
     tar -xzvf file_name.tar.gz
     ```
     Заменете `file_name.tar.gz` с името на вашия архивен файл.

3. **Отваряне на solution в IDE:**
   - **Visual Studio:**
     - Стартирайте Visual Studio, отидете на `File > Open > Project/Solution`, и навигирайте до мястото, където сте разархивирали проекта. Изберете `.sln` файла и отворете го.
   - **Rider:**
     - Стартирайте Rider, изберете `Open` от началния екран, навигирайте до директорията на проекта и изберете `.sln` или директорията на проекта.

4. **Сваляне и инсталиране на необходимите пакети:**
   - Обикновено, IDE като Visual Studio или Rider автоматично ще идентифицира и предложи да свали и инсталира липсващите пакети при първото отваряне на проекта.
   - Можете също така да използвате NuGet Package Manager (в Visual Studio, `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`) или сходен инструмент в Rider за ръчно управление и инсталиране на пакетите според инструкциите в README файла на проекта.

Следвайки тези стъпки, трябва да сте в състояние да конфигурирате и стартирате приложението   успешно.
