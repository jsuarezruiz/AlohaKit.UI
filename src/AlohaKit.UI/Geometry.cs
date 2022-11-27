namespace AlohaKit.UI
{
    public interface IGeometry
    {
        PathF GetPath(Rect bounds);
    }

    public abstract class Geometry : BindableObject, IGeometry
    {
        public abstract void AppendPath(PathF path, Rect viewBounds);

        PathF IGeometry.GetPath(Rect bounds)
        {
            var path = new PathF();
         
            AppendPath(path, bounds);

            return path;
        }
    }
}