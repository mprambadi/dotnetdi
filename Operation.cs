using System;
namespace webApiDi
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }
    public class Operation : IOperationScoped, IOperationSingleton, IOperationTransient
    {
        public Operation(Guid id)
        {
            OperationId = id;
        }
        public Operation() : this(Guid.NewGuid())
        {
        }

        public Guid OperationId
        {
            get; private set;
        }
    }

    public class TestService
    {
       public IOperationTransient _transientOperation;
       public IOperationScoped _scopedOperation;
       public IOperationSingleton _singletonOperation;
       public TestService(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation
        )
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }

    }
}