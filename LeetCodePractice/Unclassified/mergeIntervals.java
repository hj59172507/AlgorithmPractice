/*
Given a collection of intervals, merge all overlapping intervals.
Example 1:
Input: [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
*/

//sort base on the interval start, then merge adjcent interval based on values
/**
 * Definition for an interval.
 * public class Interval {
 *     int start;
 *     int end;
 *     Interval() { start = 0; end = 0; }
 *     Interval(int s, int e) { start = s; end = e; }
 * }
 */
class Solution {
    private class myComparator implements Comparator<Interval>{
        @Override
        public int compare(Interval a, Interval b){
            return a.start < b.start ? -1 : a.start == b.start ?  0 : 1;
        }
    }
    public List<Interval> merge(List<Interval> intervals) {
        Collections.sort(intervals, new myComparator());
        LinkedList<Interval> merged = new LinkedList<>();
        for(Interval i : intervals){
            if(merged.isEmpty() || merged.getLast().end < i.start){
                merged.add(i);
            }
            else{
                merged.getLast().end = Math.max(merged.getLast().end, i.end);
            }
        }
        return merged;
    }
}