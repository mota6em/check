package data.structure;
import java.util.*;
import java.io.*;
public class MultiSet<E>{
    private HashMap<E,Integer> elemToCount;
    public MultiSet(E[] arr){
            elemToCount = new HashMap<E,Integer>();
            for(E e : arr){
                elemToCount.put(e,1);
            }
    }
    public MultiSet(){
        elemToCount = new HashMap<E,Integer>();
    }
    public int add(E e){
        if(!elemToCount.containsKey(e)){
            elemToCount.put(e,0);
        }
        int newValue = elemToCount.get(e) + 1;
        elemToCount.put(e,newValue);
        return newValue;
    }
    public MultiSet<E> intersect(MultiSet<E> ms){

        MultiSet<E> result = new MultiSet<E>();
        for(Map.Entry<E,Integer> entry : elemToCount.entrySet()){
            E key = entry.getKey();
            if(ms.elemToCount.containsKey(key)){
                int minValue = Math.min(entry.getValue(), ms.elemToCount.get(key));
                for(int i = 0; i < minValue; i++){
                    result.add(key);
                }
            }
        }
        return result;
    }
    public int getCount(E e){
        return elemToCount.get(e);
    }
    public int size(){
        int result = 0;
        for(Map.Entry<E,Integer> entry : elemToCount.entrySet()){
            result += entry.getValue();
        }
        return result;
    }
}