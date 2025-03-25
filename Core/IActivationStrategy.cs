namespace AdaptiveOctree
{
    public interface IActivationStrategy
    {
        bool ShouldActivate(IOctreeNode node);
    }
}