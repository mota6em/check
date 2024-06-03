package data.structure;
import java.util.*;

public class MultiSet<E> {
    private HashMap<E , Integer> elemToCount;
    public MultiSet(E[] Element){
        elemToCount = new HashMap<>();
        for(E elem : Element){
            if(elemToCount.containsKey(elem)){
                elemToCount.replace(elem, elemToCount.get(elem)+1);
            }
            else{
                elemToCount.put(elem,1);
            }
        }
    }
    public MultiSet(){
        elemToCount = new HashMap<>();
    }
    public int add(E elem){
        if(elemToCount.containsKey(elem)){
            elemToCount.replace(elem , elemToCount.get(elem)+1);
            return 0; // !!
        }
        else {
            elemToCount.put(elem, 1);
            return 1; //   !!
        }
    }
    public int getCount(E elem){
        if(elemToCount.containsKey(elem)){
            return elemToCount.get(elem); 
        }
        else {
            return 0; 
        }
    }
    public MultiSet<E> intersect(MultiSet<E> other)
    {
        Integer [] e;
        MultiSet<E> result = new MultiSet<>();
        for(E elem : elemToCount.keySet()){
            if(other.elemToCount.containsKey(elem)){
                int a = elemToCount.get(elem);
                int b = other.elemToCount.get(elem);
                int n = Math.min(a, b);
                result.elemToCount.put(elem, n);
            }
        }
        return result;
    }
    public int size(){
        return elemToCount.values().size();
    }
    public boolean containsKey(E n){
        return elemToCount.containsKey(n);
    } 
}
