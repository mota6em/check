package worker.schedule;

import java.util.*;

public class WorkerSchedule {
    private HashMap<Integer, HashSet<String>> weekToWorkers;
    public WorkerSchedule(){
        weekToWorkers = new HashMap<>();
    }
    public void add(int n, HashSet<String> hs){
        weekToWorkers.put(n,hs);
    }
    public void add(HashSet<Integer> hs, ArrayList<String> ls){
        HashSet<String> workers = new HashSet<String>();
        for ( String s : ls) {
            workers.add(s);
        }
        for(int n : hs){
            weekToWorkers.put(n, workers);
        }
    }
    public boolean isWorkingOnWeek(String name, int n){ // what is wrong in this method
        HashSet<String> worker = weekToWorkers.get(n);
        return worker != null && worker.contains(name);
    }
    public HashSet<Integer> getWorkWeeks(String s){
        HashSet<Integer> output = new HashSet<>();
        for(var e : weekToWorkers.entrySet()){
            if(e.getValue().contains(s)){
                output.add(e.getKey());
            }
        }
        return output;
    }
}
