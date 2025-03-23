public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Render();
}

// Конкретні продукти (Windows)
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Button");
    }
}

public class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows Checkbox");
    }
}

// Конкретні продукти (macOS)
public class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac Button");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering Mac Checkbox");
    }
}

// Абстрактна фабрика
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Конкретні фабрики
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Render()
    {
        _button.Render();
        _checkbox.Render();
    }
}

class Program
{
    static void Main()
    {
        IGUIFactory factory = new WindowsFactory(); 
        Application app = new Application(factory);
        app.Render();
    }
}
