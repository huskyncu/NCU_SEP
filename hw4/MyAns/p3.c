#include <stdio.h>
#include "awk_sem.h"

main() {
    int i = 0 ;
    // *** please insert proper semaphore initialization here
   // int semid3 = create_sem(".", 'c', 0); // Initialize semaphore for p3 with value 1
   int semid3 = get_sem(".", 'c'); // get semaphore for p1
    int semid1 = get_sem(".", 'a');       // Get semaphore for p1
     int semid2 = get_sem(".", 'b');       // Get semaphore for p1
    do {
        // *** this is where you should place semaphore 
       // Wait for its turn
       P(semid3); //1->0     1->0
       
       printf("P3333333 is here\n"); i++;  
       
       V(semid1);     //-1  ->   0      -1->0
   
    }  while (i< 200);
}