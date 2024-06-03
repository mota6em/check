package data.structure;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class MultiSetTest{
    @Test 
    public void getCountTest(){
        data.structure.MultiSet<Integer> MultiSetInteger = new data.structure.MultiSet<Integer>(new Integer[]{32,33,34});
        data.structure.MultiSet<String> MultiSetString = new data.structure.MultiSet<String>(new String[]{"hello","world"});
        int n = 32;
        MultiSetInteger.add(n);
        MultiSetInteger.add(33);
        MultiSetString.add("hello");
        assertEquals(2,MultiSetInteger.getCount(32));
        assertEquals(1,MultiSetInteger.getCount(34));
        assertEquals(1,MultiSetString.getCount("world"));
        assertEquals(2,MultiSetString.getCount("hello"));
    }

    @Test 
    public void sndTest(){
        data.structure.MultiSet<Integer> MultiSetInteger = new data.structure.MultiSet<Integer>(new Integer[]{32,33,34});
        data.structure.MultiSet<Integer> MultiSetInteger1 = new data.structure.MultiSet<Integer>(new Integer[]{34});
        data.structure.MultiSet<Integer> result = MultiSetInteger.intersect(MultiSetInteger1); 
        assertEquals(1,result.size());
    }
}