

using UnityEngine;

public class outcode
{

    bool up, down, left, right;

    public outcode(Vector2 p)
    {
        up = ( p.y > 1);

        down = (p.y < -1);

        left = (p.x < -1);

        right = (p.x < 1);



        /* if ( p.y > 1 )
         {
             up = true;
         }
         else
         {
             up = false;
         }*/


    }
   
    public outcode()
    {
        up = false;
        down = false;
        left = false;
        right = false;
    }

    public outcode(bool UP, bool DOWN, bool LEFT, bool RIGHT)
    {
        up =UP;
        down = DOWN;
        left = LEFT;
        right = RIGHT;
    }

    public void print()
    {
        string s = (up ? "1" : "0") + (down ? "1" : "0") + (left ? "1" : "0") + (right ? "1" : "0");

    }

    public static outcode operator + (outcode a, outcode b )
    {
        
        return new outcode(a.up || b.up, a.down || b.down, a.left || b.left,  a.right || b.right);

    }

    public static outcode operator *(outcode a, outcode b)
    {

        return new outcode(a.up && b.up, a.down && b.down, a.left && b.left, a.right && b.right);

    }

    public static bool operator == (outcode a, outcode b)
    {

        return (a.up == b.up) && (a.down == b.down) && (a.left == b.left) && (a.right == b.right);

    }

    public static bool operator !=(outcode a, outcode b)
    {

        return !(a == b);

    }

}
