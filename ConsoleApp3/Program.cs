using System;

class Piano
{
    private int[] currentOctave; 
    private int currentKey; 

    
    public Piano()
    {
       
        currentOctave = new int[] { 261, 293, 329, 349, 392, 440, 493 };
        currentKey = 0;
    }

    
    private void PlaySound(int frequency)
    {
        Console.Beep(frequency, 500); 
    }

    
    private void ChangeOctave(int octave)
    {
        
        switch (octave)
        {
            case 1:
                currentOctave = new int[] { 261, 293, 329, 349, 392, 440, 493 };
                break;
            case 2:
                currentOctave = new int[] { 523, 587, 659, 698, 784, 880, 987 };
                break;
            case 3:
                currentOctave = new int[] { 1046, 1175, 1318, 1397, 1568, 1760, 1976 };
                break;
            default:
                Console.WriteLine("Некорректный выбор октавы.");
                break;
        }
    }

    
    public void HandleKeyPress(ConsoleKeyInfo keyInfo)
    {
        
        if (keyInfo.Key >= ConsoleKey.F1 && keyInfo.Key <= ConsoleKey.F12)
        {
            int octave = (int)keyInfo.Key - (int)ConsoleKey.F1 + 1;
            ChangeOctave(octave);
        }
        
        else if (keyInfo.KeyChar >= 'A' && keyInfo.KeyChar <= 'G')
        {
            
            int keyIndex = keyInfo.KeyChar - 'A';

            
            if (keyIndex >= 0 && keyIndex < currentOctave.Length)
            {
                PlaySound(currentOctave[keyIndex]);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Привет! Для игры на пианино используйте клавиши от A до G.");
        Console.WriteLine("Для изменения октавы используйте клавиши F1, F2, F3 и т.п.");
        Console.WriteLine("Для выхода нажмите клавишу Q.");

        Piano piano = new Piano();

        // Цикл для обработки нажатий клавиш
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Если нажата клавиша Q, выходим из цикла
            if (keyInfo.Key == ConsoleKey.Q)
                break;

            piano.HandleKeyPress(keyInfo);
        }

        Console.WriteLine("Спасибо за игру! До свидания.");
    }
}