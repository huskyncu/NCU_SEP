#include <stdio.h>
#include "awk_sem.h"

main() {
    int i = 0 ;
    // *** please insert proper semaphore initialization here
     int semid1 = get_sem(".", 'a'); 
    int semid2 = get_sem(".", 'b'); 
    int semid3 = get_sem(".", 'c');   
    do {
        // *** this is where you should place semaphore 
        P(semid2);
       printf("P222222222 is here\n"); i++ ;
       V(semid3);     //semid3->0->1
       V(semid3);   //semid3->0->1
      
      
       // *** this is where you should place semaphore
   
    }  while (i < 100);
}