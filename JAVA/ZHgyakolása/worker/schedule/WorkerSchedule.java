package worker.schedule;

// import java.util.HashMap;
// import java.util.HashSet;
import java.util.*;
public class WorkerSchedule
{
    private HashMap<Integer, HashSet<String>> weekToWorkers;
    public WorkerSchedule(){
        weekToWorkers = new HashMap<Integer, HashSet<String>>();
    }
    public void add(int n, HashSet<String> hs){
        if(!weekToWorkers.containsKey(n)){
            weekToWorkers.put(n,new HashSet<String>());
        }
        weekToWorkers.get(n).addAll(hs);
    }
    public void add(HashSet<Integer> weeks, ArrayList<String> workers){
        HashSet<String> workerss = new HashSet<String>();
        for(String s : workers){
            workerss.add(s);
        }
        for(Integer week : weeks){
            if(!weekToWorkers.containsKey(week)) {weekToWorkers.put(week,new HashSet<String>());}
            weekToWorkers.get(week).addAll(workerss);
        }
    }
    public boolean isWorkingOnWeek(String str, int n){
        //toDo
        HashSet<String> workers = weekToWorkers.get(n);
    return workers != null && workers.contains(str);
    }
    public HashSet<Integer> getWorkWeeks(String str){
        HashSet<Integer> result = new HashSet<>();
        for(Map.Entry<Integer, HashSet<String>> entry : weekToWorkers.entrySet()){
            if( entry.getValue() != null && entry.getValue().contains(str)){
                result.add(entry.getKey());
            }
        }
        return result;
 
    }
}

    // public void add(int week , HashSet<String> workers){
    //     if(!weekToWorkers.containsKey(week)){
    //         weekToWorkers.put(week , new HashSet<String>());
    //     }
    //     weekToWorkers.get(week).addAll(workers);
    // }
    // public void add(HashSet<Integer> weeks , ArrayList<String> workers){
    //     HashSet<String> working = new HashSet<String>();
    //     for(String worker : workers){
    //         working.add(worker);
    //     }
    //     for(Integer week : weeks){
    //         add(week, working);
    //     }
    // }
    // public boolean isWorkingOnWeek(String worker, int week){
    //     return weekToWorkers.containsKey(week) && weekToWorkers.get(week).contains(worker);
    // }
    // public HashSet<Integer> getWorkWeeks(String worker){
    //     HashSet <Integer> workWeeks  = new HashSet<Integer>();
    //     for(Map.Entry<Integer, HashSet<String>> entry : weekToWorkers.entrySet()){
    //         if(entry.getValue().contains(worker)){
    //             workWeeks.add(entry.getKey());
    //         }
    //     }
    //     return workWeeks;
    // }
    // public static void main(String[] args) {
        
    // }