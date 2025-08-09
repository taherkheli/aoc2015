namespace aoc.D23
{
  public class Computer(Instruction[] program)
  {
    private uint _a = 0;
    private uint _b = 0;
    private int _ip = 0;               
    private readonly Instruction[] _program = program;

    public uint B { get => _b; set => _b = value; }

    public void Execute(bool isPartII = false)
    {
      if (isPartII)
        _a = 1;

      var exit = false;

      while (!exit)
      {
        var curr = _program[_ip];

        switch (curr.OpCode)
        {
          case OpCode.Half:
            Half(curr.Op1);
            break;
          case OpCode.Triple:
            Triple(curr.Op1);
            break;
          case OpCode.Increment:
            Increment(curr.Op1);
            break;
          case OpCode.Jump:
            Jump(curr.Op1);
            break;
          case OpCode.JumpIfEven:
            JumpIfEven(curr.Op1, curr.Op2);
            break;
          case OpCode.JumpIfOne:
            JumpIfOne(curr.Op1, curr.Op2);
            break;
          case OpCode.Exit:
            exit = true;
            break;
          case OpCode.Unknown:
          default:
            throw new Exception("Should not have happened!!");
        }
      }

      //reset _ip etc. here
    }

    private void Half(string op1)
    {
      switch (op1[0])
      {
        case 'a':
          _a /= 2;
          break;
        case 'b':
          _b /= 2;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Triple(string op1)
    {
      switch (op1[0])
      {
        case 'a':
          _a *= 3;
          break;
        case 'b':
          _b *= 3;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Increment(string op1)
    {
      switch (op1[0])
      {
        case 'a':
          _a++;
          break;
        case 'b':
          _b++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }

      _ip++;
    }

    private void Jump(string op1)
    {
      var offset = int.Parse(op1);
      _ip += offset;
    }

    private void JumpIfEven(string op1, string op2)
    {
      var offset = int.Parse(op2);

      switch (op1[0])
      {
        case 'a':
          if (_a % 2 == 0)
            _ip += offset;
          else
            _ip++;
          break;
        case 'b':
          if (_b % 2 == 0)
            _ip += offset;
          else
            _ip++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }
    }

    private void JumpIfOne(string op1, string op2)
    {
      var offset = int.Parse(op2);

      switch (op1[0])
      {
        case 'a':
          if (_a == 1)
            _ip += offset;
          else
            _ip++;
          break;
        case 'b':
          if (_b == 1)
            _ip += offset;
          else
            _ip++;
          break;
        default:
          throw new Exception("Should not have happened!!");
      }
    }
  }
}
