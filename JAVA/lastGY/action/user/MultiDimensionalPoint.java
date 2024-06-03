package action.user;
// import action.Scalable;
// import action.Undoable;
import java.util.*;
import java.io.*;

public class MultiDimensionalPoint implements action.Undoable , action.Scalable, Comparable<MultiDimensionalPoint>{

    private int[] coordinates;
    private int[] lastCoordinates;
    public boolean equals(Object obj){
        if(this == obj){
            return true;
        }
        if(obj==null) return false;
        // if(obj instanceof MultiDimensionalPoint newhtr){
        //     return Arrays.equals(this.coordinates == newhtr.coordinates);
        // }
                if (obj instanceof MultiDimensionalPoint mdp) {
            return Arrays.equals(this.coordinates, mdp.coordinates);
            //return Arrays.equals(this.coordinates, mdp.coordinates) && Arrays.equals(this.lastCoordinates, mdp.lastCoordinates);
        }
        return false;
    }
    // @Override
    public int hashCode(){
        return Objects.hash(coordinates);
    }
    public int compareTo(MultiDimensionalPoint other){
        int minV = coordinates.length - other.coordinates.length;
        if(minV != 0){return minV;}
        for(int i = 0; i <coordinates.length; i++){
            int r = coordinates[i] - other.coordinates[i];
            if(r != 0){return r; }
        }
        return 0;
    }
    public MultiDimensionalPoint(int... arr){
        //todo
    }
    public int get(int n){
        return coordinates[n];
    }
    public void set(int n1,int n2){
        coordinates[n1] = n2;
    }
    @Override
    public void scale(int n){
        for(int i = 0 ; i < coordinates.length ; i++){
            coordinates[i] += n;
        }
    }
    @Override
    public void undoLast(){}
    private void saveToLast(){}
}