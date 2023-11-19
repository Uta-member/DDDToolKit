namespace DDDToolKit.DomainService
{
    public abstract class DomainServiceBase
    {
        protected IDomainServiceOption domainServiceOption;

        public DomainServiceBase(IDomainServiceOption domainServiceOption)
        {
            this.domainServiceOption = domainServiceOption;
        }
    }
}
