Context context = new Context();
context.ChangeField();
context.ChangeField();
context.ChangeField();


public class Context
{
    public int ChangingField { get; set; }

    public IState state { get; set; }

    public Context()
    {
        ChangingField = 0;
        this.state = new NewState();
    }

    public void ChangeState(IState state)
    {
        this.state = state;
    }

    public void ChangeField()
    {
        state.ChangeField(this);
        Console.WriteLine(ChangingField);
    }
}

public interface IState
{
    void ChangeField(Context context);

    void Close(Context context);
}

public class NewState : IState
{
    public void ChangeField(Context context)
    {
        context.ChangingField = 1;
        context.ChangeState(new PendingState());
    }

    public void Close(Context context)
    {
        context.ChangeState(new CloseState());
    }
}

public class PendingState : IState
{
    public void ChangeField(Context context)
    {
        context.ChangingField = 2;
        context.ChangeState(new CloseState());
    }

    public void Close(Context context)
    {
        context.ChangeState(new CloseState());
    }
}

public class CloseState : IState
{
    public void ChangeField(Context context)
    {
        throw new Exception("Invalid action for the current state");
    }

    public void Close(Context context)
    {
        throw new Exception("Invalid action for the current state");
    }
}



