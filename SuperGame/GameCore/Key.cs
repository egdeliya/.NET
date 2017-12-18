﻿namespace GameCore
{
    public enum Key
    {
        //
        // Сводка:
        //     Нет нажатых клавиш.
        None = 0,

        //
        // Сводка:
        //     Клавиша "Отмена".
        Cancel = 1,

        //
        // Сводка:
        //     Клавиша BACKSPACE.
        Back = 2,

        //
        // Сводка:
        //     Клавиша TAB.
        Tab = 3,

        //
        // Сводка:
        //     Клавиша перевода строки.
        LineFeed = 4,

        //
        // Сводка:
        //     Клавиша CLEAR.
        Clear = 5,

        //
        // Сводка:
        //     Клавиша RETURN.
        Return = 6,

        //
        // Сводка:
        //     Клавиша ВВОД.
        Enter = 6,

        //
        // Сводка:
        //     Клавиша паузы.
        Pause = 7,

        //
        // Сводка:
        //     Клавиша CAPS LOCK.
        Capital = 8,

        //
        // Сводка:
        //     Клавиша CAPS LOCK.
        CapsLock = 8,

        //
        // Сводка:
        //     Клавиша режима "Кана" редактора метода ввода.
        KanaMode = 9,

        //
        // Сводка:
        //     Клавиша режима "Хангыль" редактора метода ввода.
        HangulMode = 9,

        //
        // Сводка:
        //     Клавиша режима "Джунджа" редактора метода ввода.
        JunjaMode = 10,

        //
        // Сводка:
        //     Клавиша режима "Последний" редактора метода ввода.
        FinalMode = 11,

        //
        // Сводка:
        //     Клавиша режима "Ханджа" редактора метода ввода.
        HanjaMode = 12,

        //
        // Сводка:
        //     Клавиша режима "Кандзи" редактора метода ввода.
        KanjiMode = 12,

        //
        // Сводка:
        //     Клавиша ESC.
        Escape = 13,

        //
        // Сводка:
        //     Клавиша преобразования в редакторе метода ввода.
        ImeConvert = 14,

        //
        // Сводка:
        //     Клавиша без преобразования в редакторе метода ввода.
        ImeNonConvert = 15,

        //
        // Сводка:
        //     Клавиша принятия в редакторе метода ввода.
        ImeAccept = 16,

        //
        // Сводка:
        //     Запрос на изменение режима редактора метода ввода.
        ImeModeChange = 17,

        //
        // Сводка:
        //     Клавиша ПРОБЕЛ.
        Space = 18,

        //
        // Сводка:
        //     Клавиша PAGE UP.
        Prior = 19,

        //
        // Сводка:
        //     Клавиша PAGE UP.
        PageUp = 19,

        //
        // Сводка:
        //     Клавиша PAGE DOWN.
        Next = 20,

        //
        // Сводка:
        //     Клавиша PAGE DOWN.
        PageDown = 20,

        //
        // Сводка:
        //     Клавиша END.
        End = 21,

        //
        // Сводка:
        //     Клавиша HOME.
        Home = 22,

        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВЛЕВО.
        Left = 23,

        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВВЕРХ.
        Up = 24,

        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВПРАВО.
        Right = 25,

        //
        // Сводка:
        //     Клавиша СТРЕЛКА ВНИЗ.
        Down = 26,

        //
        // Сводка:
        //     Клавиша "Выбрать".
        Select = 27,

        //
        // Сводка:
        //     Клавиша "Печать".
        Print = 28,

        //
        // Сводка:
        //     Клавиша "Выполнить".
        Execute = 29,

        //
        // Сводка:
        //     Клавиша PRINT SCREEN.
        Snapshot = 30,

        //
        // Сводка:
        //     Клавиша PRINT SCREEN.
        PrintScreen = 30,

        //
        // Сводка:
        //     Клавиша INSERT.
        Insert = 31,

        //
        // Сводка:
        //     Клавиша DELETE.
        Delete = 32,

        //
        // Сводка:
        //     Клавиша справки.
        Help = 33,

        //
        // Сводка:
        //     Клавиша 0 (нуль).
        D0 = 34,

        //
        // Сводка:
        //     Клавиша 1 (один).
        D1 = 35,

        //
        // Сводка:
        //     Клавиша 2.
        D2 = 36,

        //
        // Сводка:
        //     Клавиша 3.
        D3 = 37,

        //
        // Сводка:
        //     Клавиша 4.
        D4 = 38,

        //
        // Сводка:
        //     Клавиша 5.
        D5 = 39,

        //
        // Сводка:
        //     Клавиша 6.
        D6 = 40,

        //
        // Сводка:
        //     Клавиша 7.
        D7 = 41,

        //
        // Сводка:
        //     Клавиша 8.
        D8 = 42,

        //
        // Сводка:
        //     Клавиша 9.
        D9 = 43,

        //
        // Сводка:
        //     Клавиша A.
        A = 44,

        //
        // Сводка:
        //     Клавиша B.
        B = 45,

        //
        // Сводка:
        //     Клавиша C.
        C = 46,

        //
        // Сводка:
        //     Клавиша D.
        D = 47,

        //
        // Сводка:
        //     Клавиша E.
        E = 48,

        //
        // Сводка:
        //     Клавиша F.
        F = 49,

        //
        // Сводка:
        //     Клавиша G.
        G = 50,

        //
        // Сводка:
        //     Клавиша H.
        H = 51,

        //
        // Сводка:
        //     Клавиша I.
        I = 52,

        //
        // Сводка:
        //     Клавиша J.
        J = 53,

        //
        // Сводка:
        //     Клавиша K.
        K = 54,

        //
        // Сводка:
        //     Клавиша L.
        L = 55,

        //
        // Сводка:
        //     Клавиша M.
        M = 56,

        //
        // Сводка:
        //     Клавиша N.
        N = 57,

        //
        // Сводка:
        //     Клавиша O.
        O = 58,

        //
        // Сводка:
        //     Клавиша P.
        P = 59,

        //
        // Сводка:
        //     Клавиша Q.
        Q = 60,

        //
        // Сводка:
        //     Клавиша R.
        R = 61,

        //
        // Сводка:
        //     Клавиша S.
        S = 62,

        //
        // Сводка:
        //     Клавиша T.
        T = 63,

        //
        // Сводка:
        //     Клавиша U.
        U = 64,

        //
        // Сводка:
        //     Клавиша V.
        V = 65,

        //
        // Сводка:
        //     Клавиша W.
        W = 66,

        //
        // Сводка:
        //     Клавиша X.
        X = 67,

        //
        // Сводка:
        //     Клавиша Y.
        Y = 68,

        //
        // Сводка:
        //     Клавиша Z.
        Z = 69,

        //
        // Сводка:
        //     Левая клавиша с логотипом Windows (клавиатура Microsoft Natural Keyboard).
        LWin = 70,

        //
        // Сводка:
        //     Правая клавиша с логотипом Windows (клавиатура Microsoft Natural Keyboard).
        RWin = 71,

        //
        // Сводка:
        //     Клавиша приложения (клавиатура Microsoft Natural Keyboard).
        Apps = 72,

        //
        // Сводка:
        //     Клавиша перевода компьютера в спящий режим.
        Sleep = 73,

        //
        // Сводка:
        //     Клавиша 0 на цифровой клавиатуре.
        NumPad0 = 74,

        //
        // Сводка:
        //     Клавиша 1 на цифровой клавиатуре.
        NumPad1 = 75,

        //
        // Сводка:
        //     Клавиша 2 на цифровой клавиатуре.
        NumPad2 = 76,

        //
        // Сводка:
        //     Клавиша 3 на цифровой клавиатуре.
        NumPad3 = 77,

        //
        // Сводка:
        //     Клавиша 4 на цифровой клавиатуре.
        NumPad4 = 78,

        //
        // Сводка:
        //     Клавиша 5 на цифровой клавиатуре.
        NumPad5 = 79,

        //
        // Сводка:
        //     Клавиша 6 на цифровой клавиатуре.
        NumPad6 = 80,

        //
        // Сводка:
        //     Клавиша 7 на цифровой клавиатуре.
        NumPad7 = 81,

        //
        // Сводка:
        //     Клавиша 8 на цифровой клавиатуре.
        NumPad8 = 82,

        //
        // Сводка:
        //     Клавиша 9 на цифровой клавиатуре.
        NumPad9 = 83,

        //
        // Сводка:
        //     Клавиша умножения.
        Multiply = 84,

        //
        // Сводка:
        //     Клавиша сложения.
        Add = 85,

        //
        // Сводка:
        //     Клавиша разделителя.
        Separator = 86,

        //
        // Сводка:
        //     Клавиша вычитания.
        Subtract = 87,

        //
        // Сводка:
        //     Клавиша десятичного разделителя.
        Decimal = 88,

        //
        // Сводка:
        //     Клавиша деления.
        Divide = 89,

        //
        // Сводка:
        //     Клавиша F1.
        F1 = 90,

        //
        // Сводка:
        //     Клавиша F2.
        F2 = 91,

        //
        // Сводка:
        //     Клавиша F3.
        F3 = 92,

        //
        // Сводка:
        //     Клавиша F4.
        F4 = 93,

        //
        // Сводка:
        //     Клавиша F5.
        F5 = 94,

        //
        // Сводка:
        //     Клавиша F6.
        F6 = 95,

        //
        // Сводка:
        //     Клавиша F7.
        F7 = 96,

        //
        // Сводка:
        //     Клавиша F8.
        F8 = 97,

        //
        // Сводка:
        //     Клавиша F9.
        F9 = 98,

        //
        // Сводка:
        //     Клавиша F10.
        F10 = 99,

        //
        // Сводка:
        //     Клавиша F11.
        F11 = 100,

        //
        // Сводка:
        //     Клавиша F12.
        F12 = 101,

        //
        // Сводка:
        //     Клавиша F13.
        F13 = 102,

        //
        // Сводка:
        //     Клавиша F14.
        F14 = 103,

        //
        // Сводка:
        //     Клавиша F15.
        F15 = 104,

        //
        // Сводка:
        //     Клавиша F16.
        F16 = 105,

        //
        // Сводка:
        //     Клавиша F17.
        F17 = 106,

        //
        // Сводка:
        //     Клавиша F18.
        F18 = 107,

        //
        // Сводка:
        //     Клавиша F19.
        F19 = 108,

        //
        // Сводка:
        //     Клавиша F20.
        F20 = 109,

        //
        // Сводка:
        //     Клавиша F21.
        F21 = 110,

        //
        // Сводка:
        //     Клавиша F22.
        F22 = 111,

        //
        // Сводка:
        //     Клавиша F23.
        F23 = 112,

        //
        // Сводка:
        //     Клавиша F24.
        F24 = 113,

        //
        // Сводка:
        //     Клавиша NUM LOCK.
        NumLock = 114,

        //
        // Сводка:
        //     Клавиша SCROLL LOCK.
        Scroll = 115,

        //
        // Сводка:
        //     Левая клавиша SHIFT.
        LeftShift = 116,

        //
        // Сводка:
        //     Правая клавиша SHIFT.
        RightShift = 117,

        //
        // Сводка:
        //     Левая клавиша CTRL.
        LeftCtrl = 118,

        //
        // Сводка:
        //     Правая клавиша CTRL.
        RightCtrl = 119,

        //
        // Сводка:
        //     Левая клавиша ALT.
        LeftAlt = 120,

        //
        // Сводка:
        //     Правая клавиша ALT.
        RightAlt = 121,

        //
        // Сводка:
        //     Клавиша браузера "Назад".
        BrowserBack = 122,

        //
        // Сводка:
        //     Клавиша браузера "Вперед".
        BrowserForward = 123,

        //
        // Сводка:
        //     Клавиша браузера "Обновить".
        BrowserRefresh = 124,

        //
        // Сводка:
        //     Клавиша браузера "Остановить".
        BrowserStop = 125,

        //
        // Сводка:
        //     Клавиша браузера "Поиск".
        BrowserSearch = 126,

        //
        // Сводка:
        //     Клавиша браузера "Избранное".
        BrowserFavorites = 127,

        //
        // Сводка:
        //     Клавиша браузера "Главная".
        BrowserHome = 128,

        //
        // Сводка:
        //     Клавиша выключения звука.
        VolumeMute = 129,

        //
        // Сводка:
        //     Клавиша уменьшения громкости.
        VolumeDown = 130,

        //
        // Сводка:
        //     Клавиша увеличения громкости.
        VolumeUp = 131,

        //
        // Сводка:
        //     Клавиша "Следующая запись".
        MediaNextTrack = 132,

        //
        // Сводка:
        //     Клавиша "Предыдущая запись".
        MediaPreviousTrack = 133,

        //
        // Сводка:
        //     Клавиша остановки воспроизведения.
        MediaStop = 134,

        //
        // Сводка:
        //     Клавиша приостановки воспроизведения.
        MediaPlayPause = 135,

        //
        // Сводка:
        //     Клавиша запуска почты.
        LaunchMail = 136,

        //
        // Сводка:
        //     Клавиша выбора мультимедиа.
        SelectMedia = 137,

        //
        // Сводка:
        //     Клавиша запуска приложения 1.
        LaunchApplication1 = 138,

        //
        // Сводка:
        //     Клавиша запуска приложения 2.
        LaunchApplication2 = 139,

        //
        // Сводка:
        //     Клавиша OEM 1.
        Oem1 = 140,

        //
        // Сводка:
        //     Клавиша OEM с точкой с запятой.
        OemSemicolon = 140,

        //
        // Сводка:
        //     Клавиша OEM со сложением.
        OemPlus = 141,

        //
        // Сводка:
        //     Клавиша OEM с запятой.
        OemComma = 142,

        //
        // Сводка:
        //     Клавиша OEM с минусом.
        OemMinus = 143,

        //
        // Сводка:
        //     Клавиша OEM с точкой.
        OemPeriod = 144,

        //
        // Сводка:
        //     Клавиша OEM 2.
        Oem2 = 145,

        //
        // Сводка:
        //     Клавиша OEM с вопросительным знаком.
        OemQuestion = 145,

        //
        // Сводка:
        //     Клавиша OEM 3.
        Oem3 = 146,

        //
        // Сводка:
        //     Клавиша OEM с тильдой.
        OemTilde = 146,

        //
        // Сводка:
        //     Клавиша ABNT_C1 (Бразилия).
        AbntC1 = 147,

        //
        // Сводка:
        //     Клавиша ABNT_C2 (Бразилия).
        AbntC2 = 148,

        //
        // Сводка:
        //     Клавиша OEM 4.
        Oem4 = 149,

        //
        // Сводка:
        //     Клавиша OEM с открывающими скобками.
        OemOpenBrackets = 149,

        //
        // Сводка:
        //     Клавиша OEM 5.
        Oem5 = 150,

        //
        // Сводка:
        //     Клавиша OEM с вертикальной чертой.
        OemPipe = 150,

        //
        // Сводка:
        //     Клавиша OEM 6.
        Oem6 = 151,

        //
        // Сводка:
        //     Клавиша OEM с закрывающими скобками.
        OemCloseBrackets = 151,

        //
        // Сводка:
        //     Клавиша OEM 7.
        Oem7 = 152,

        //
        // Сводка:
        //     Клавиша OEM с кавычками.
        OemQuotes = 152,

        //
        // Сводка:
        //     Клавиша OEM 8.
        Oem8 = 153,

        //
        // Сводка:
        //     Клавиша OEM 102.
        Oem102 = 154,

        //
        // Сводка:
        //     Клавиша OEM с обратной косой чертой.
        OemBackslash = 154,

        //
        // Сводка:
        //     Специальная клавиша, маскирующая фактическую клавишу, обрабатываемую редактором
        //     метода ввода.
        ImeProcessed = 155,

        //
        // Сводка:
        //     Специальный клавиша, маскирующая фактическую клавишу, обрабатываемую в качестве
        //     системной клавиши.
        System = 156,

        //
        // Сводка:
        //     Клавиша OEM ATTN.
        OemAttn = 157,

        //
        // Сводка:
        //     Клавиша DBE_ALPHANUMERIC.
        DbeAlphanumeric = 157,

        //
        // Сводка:
        //     Клавиша OEM FINISH.
        OemFinish = 158,

        //
        // Сводка:
        //     Клавиша DBE_KATAKANA.
        DbeKatakana = 158,

        //
        // Сводка:
        //     Клавиша OEM COPY.
        OemCopy = 159,

        //
        // Сводка:
        //     Клавиша DBE_HIRAGANA.
        DbeHiragana = 159,

        //
        // Сводка:
        //     Клавиша OEM AUTO.
        OemAuto = 160,

        //
        // Сводка:
        //     Клавиша DBE_SBCSCHAR.
        DbeSbcsChar = 160,

        //
        // Сводка:
        //     Клавиша OEM ENLW.
        OemEnlw = 161,

        //
        // Сводка:
        //     Клавиша DBE_DBCSCHAR.
        DbeDbcsChar = 161,

        //
        // Сводка:
        //     Клавиша OEM BACKTAB.
        OemBackTab = 162,

        //
        // Сводка:
        //     Клавиша DBE_ROMAN.
        DbeRoman = 162,

        //
        // Сводка:
        //     Клавиша ATTN.
        Attn = 163,

        //
        // Сводка:
        //     Клавиша DBE_NOROMAN.
        DbeNoRoman = 163,

        //
        // Сводка:
        //     Клавиша CRSEL.
        CrSel = 164,

        //
        // Сводка:
        //     Клавиша DBE_ENTERWORDREGISTERMODE.
        DbeEnterWordRegisterMode = 164,

        //
        // Сводка:
        //     Клавиша EXSEL.
        ExSel = 165,

        //
        // Сводка:
        //     Клавиша DBE_ENTERIMECONFIGMODE.
        DbeEnterImeConfigureMode = 165,

        //
        // Сводка:
        //     Клавиша ERASE EOF.
        EraseEof = 166,

        //
        // Сводка:
        //     Клавиша DBE_FLUSHSTRING.
        DbeFlushString = 166,

        //
        // Сводка:
        //     Клавиша ВОСПРОИЗВЕСТИ.
        Play = 167,

        //
        // Сводка:
        //     Клавиша DBE_CODEINPUT.
        DbeCodeInput = 167,

        //
        // Сводка:
        //     Клавиша МАСШТАБ.
        Zoom = 168,

        //
        // Сводка:
        //     Клавиша DBE_NOCODEINPUT.
        DbeNoCodeInput = 168,

        //
        // Сводка:
        //     Константа, зарезервированная для будущего использования.
        NoName = 169,

        //
        // Сводка:
        //     Клавиша DBE_DETERMINESTRING.
        DbeDetermineString = 169,

        //
        // Сводка:
        //     Клавиша PA1.
        Pa1 = 170,

        //
        // Сводка:
        //     Клавиша DBE_ENTERDLGCONVERSIONMODE.
        DbeEnterDialogConversionMode = 170,

        //
        // Сводка:
        //     Клавиша OEM очистки.
        OemClear = 171,

        //
        // Сводка:
        //     Клавиша используется вместе с другой клавишей для создания одного объединенного
        //     символа.
        DeadCharProcessed = 172
    }
}