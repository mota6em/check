package data.structure;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;

import java.util.HashMap;

import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
public class MultiSetTest {
    @Test 
    public void testConst(){
        HashMap<Integer,  Integer> test = new HashMap<>();
        test.put(2, 1);
        test.put(22, 1);
        test.put(32, 3);
        Integer[] ints = {2,22,32,32,32};
        MultiSet<Integer> fun ;
        fun = new MultiSet<>(ints);
        assertEquals(fun.size(), fun.size());
    }

    @Test
    public void testAdd(){
        Integer[] ints = {2,22,32,32,32};
        MultiSet<Integer> fun ;
        fun = new MultiSet<>(ints);
        assertEquals(1,fun.add(33));
        assertEquals(0,fun.add(32));
        assertTrue(fun.containsKey(32));
    }
    @Test 
    public void testINTERSEC(){
        Integer[] ints = {2,22,32,32,32};
        MultiSet<Integer> fun ;
        fun = new MultiSet<>(ints);

        Integer[] ints2 = {2,2,2,2,2};
        MultiSet<Integer> fun2 ;
        fun2 = new MultiSet<>(ints2);

        Integer[] i = {2};
        MultiSet<Integer> result ;
        result = new MultiSet<>(i);

        MultiSet<Integer> result2;
        result2 = fun.intersect(fun2);
        assertEquals(1 , result2.size());
        assertEquals(result.size() , result2.size());
        assertEquals(result.containsKey(2) , result2.containsKey(2));
        assertEquals(1 , result2.size());
        assertFalse(result.containsKey(55));
        assertFalse(result2.containsKey(55));
        assertEquals(1, result2.getCount(2));
        assertEquals(0, result2.getCount(2222));
    }

}
