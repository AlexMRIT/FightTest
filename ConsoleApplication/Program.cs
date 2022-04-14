using System;

public enum DamageResult : byte
{
    DamageFail = 0x00,
    DamageSuccess = 0x01,
    DamageMiss = 0x02,
    DamageCritical = 0x03,
    DamageBlock = 0x04
}

public interface ITarget
{
    public IEntity GetEntity();
}

public interface IEntity
{
    public DamageResult TakeDamage(ITarget target, Damage damage);
    public bool CheckDistance(IEntity entityFirst, IEntity entitySecond);
    public Vector3 GetPositionEntity();
    public void Move(ITarget target);
}

public struct Damage
{
    public Damage(float damageValue)
    {
        DamageValue = damageValue;
    }

    public readonly float DamageValue { get; }
}

public struct Vector3
{
    public Vector3 (float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public static float Distance(Vector3 firstVector, Vector3 secondVector)
    {
        return (float)Math.Sqrt(Math.Pow(firstVector.X - secondVector.X, 2) + 
            Math.Pow(firstVector.Y - secondVector.Y, 2) + Math.Pow(firstVector.Z - secondVector.Z, 2));
    }
}

public abstract class BaseEntity
{
    public abstract float AttackDistance { get; set; }
    public abstract float Damage { get; set; }
    public abstract float Health { get; set; }
    public abstract Vector3 CurrentPosition { get; set; }
}

public sealed class Character : BaseEntity, IEntity, ITarget
{
    public override float AttackDistance { get; set; }
    public override float Damage { get; set; }
    public override float Health { get; set; }
    public override Vector3 CurrentPosition { get; set; }

    public bool CheckDistance(IEntity entityFirst, IEntity entitySecond)
    {
        return Vector3.Distance(entityFirst.GetPositionEntity(), entitySecond.GetPositionEntity()) <= AttackDistance;
    }

    public IEntity GetEntity()
    {
        return this;
    }

    public Vector3 GetPositionEntity()
    {
        return CurrentPosition;
    }

    public void Move(ITarget target)
    {
        // Тут будет передвижение...
        throw new NotImplementedException();
    }

    public DamageResult TakeDamage(ITarget target, Damage damage)
    {
        // Тут будет сама реализация атаки :D
        throw new NotImplementedException();
    }
}

public sealed class Enemy : BaseEntity, IEntity, ITarget
{
    public override float AttackDistance { get; set; }
    public override float Damage { get; set; }
    public override float Health { get; set; }
    public override Vector3 CurrentPosition { get; set; }

    public bool CheckDistance(IEntity entityFirst, IEntity entitySecond)
    {
        return Vector3.Distance(entityFirst.GetPositionEntity(), entitySecond.GetPositionEntity()) <= AttackDistance;
    }

    public IEntity GetEntity()
    {
        return this;
    }

    public Vector3 GetPositionEntity()
    {
        return CurrentPosition;
    }

    public void Move(ITarget target)
    {
        // Тут будет передвижение...
        throw new NotImplementedException();
    }

    public DamageResult TakeDamage(ITarget target, Damage damage)
    {
        // Тут будет сама реализация атаки :D
        throw new NotImplementedException();
    }
}