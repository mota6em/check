package action.user;

import java.lang.reflect.Method;

import action.Scalable;
import action.Undoable;

public class MultiDimensionalPoint implements Undoable,Scalable {
    
    private int[] coordinates;
    public MultiDimensionalPoint(int... vararg){
        this.coordinates = vararg;
    }
    public int get(int ind){
        return coordinates[ind];
    }
    public void set(int ind, int value){
        coordinates[ind] = value;
    }
    public void scale(int n){

        try {
            // Get the scale(int) method from the action.Scalable class
            Method scaleMethod = action.Scalable.class.getMethod("scale", int.class);
            
            // Check if the scale(int) method is inherited
            if (this.getClass().getMethod("scale", int.class).getDeclaringClass().equals(action.Scalable.class)) {
                System.out.println("method MultiDimensionalPoint.scale(int) is inherited from class action.Scalable.");
            } else {
                System.out.println("method MultiDimensionalPoint.scale(int) is NOT inherited from class action.Scalable.");
            }
        } catch (NoSuchMethodException e) {
            System.out.println("method MultiDimensionalPoint.scale(int) is NOT inherited from class action.Scalable.");
        }
    }
    private void saveToLast(){

    }
    public void undoLast(){

    }
    public int[] getCoordinates()
    {
        return this.coordinates;
    }

    @Override
    public boolean equals(Object anotherObject) {
        MultiDimensionalPoint MD = (MultiDimensionalPoint) anotherObject;
        return this.coordinates == MD.getCoordinates();
    }
    
}