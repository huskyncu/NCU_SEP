#include <stdio.h>
#include "awk_sem.h"

main() {
    int i = 0 ;
    // *** Please insert proper semaphore initialization here
    int semid1 = create_sem(".", 'a', 1); // Initialize semaphore for p1 with value 1
    int semid2 = create_sem(".", 'b', 0); // Initialize semaphore for p2 with value 1
    int semid3 = create_sem(".", 'c', 0); // Initialize semaphore for p3 with value 1
    do {
        // *** this is where you should place semaphore 

       P(semid1);    // 1->0    0->LOCK
       printf("P1111111111 is here\n"); i++;
       V(semid2); 
       P(semid1);   //sturb     0->LOCK
       
      
       // *** this is where you should place semaphore
   
    }  while (i < 100) ;
}