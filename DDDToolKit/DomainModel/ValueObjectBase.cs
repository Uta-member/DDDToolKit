namespace DDDToolKit.DomainModel
{
    /// <summary>
    /// 値オブジェクトの基底クラス。
    /// </summary>
    /// <typeparam name="T">値オブジェクトクラス</typeparam>
    public abstract class ValueObjectBase<T>
    {
        /// <summary>
        /// ==で比較したときの処理。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueObjectBase<T>? left, ValueObjectBase<T>? right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// !=で比較したときの処理。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObjectBase<T>? left, ValueObjectBase<T>? right)
        {
            // ここはnullチェックなどをもうちょい考えたほうがいいかも？
            return !(left == right);
        }

        /// <summary>
        /// オブジェクトを比較したときの処理。
        /// </summary>
        /// <param name="other">比較対象のオブジェクト</param>
        /// <returns></returns>
        public abstract bool Equals(T? other);

        /// <summary>
        /// 独自のEqualsを作りたいときはこのメソッドが必須らしい。
        /// </summary>
        /// <param name="obj">比較対象のオブジェクト</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            // これを入れてキャストしてEqualsに渡さないと、再帰呼び出しして無限ループします
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return Equals((T)obj);
        }

        /// <summary>
        /// 独自のEqualsを作りたいときはこのメソッドが必須らしい。
        /// </summary>
        /// <returns></returns>
        public abstract override int GetHashCode();
    }
}
