function solve (args) {
	var first = +args[0],
		second = +args[1],
		third = +args[2],
		fourth = +args[3],
		fifth = +args[4],
		max;

	if (first > second) {
		if (second > third) {
			if(third > fourth) {
				if(fourth > fifth){
					max = first;
				}
				else if(first > fifth) {
					max = first;
				}
				else{
					max = fifth;
				}
			}
			else{
				if (first > fourth) {
					if (fourth > fifth) {
						max = first;
					}
					else if(first > fifth){
						max = first;
					}
					else{
						max = fifth;
					}
				}
				else{
					if (fourth > fifth) {
						max = fourth;
					}
					else{
						max = fifth;
					}
				}
 			}
		}
		else{
			if (first > third) {
				if (third > fourth) {
					if (fourth > fifth) {
						max = first;
					}
					else if (first > fifth) {
						max = first;
					}
					else {
						max = fifth;
					}
				}
				else {
					if (first > fourth) {
						if (fourth > fifth) {
							max = first;
						}
						else if (first > fifth) {
							max = first;
						}
						else{
							max = fift;
						}
					}
					else{
						if (fourth > fifth) {
							max = fourth;
						}
						else{
							max = fift;
						}
					}
				}
			}
			else {
				if (third > fourth) {
					if (fourth > fifth) {
						max = third;
					}
					else if (third > fifth) {
						max = third;
					}
					else {
						max = fifth;
					}
				}
				else {
					if (fourth > fifth) {
						max = fourth;
					}
					else {
						max = fifth;
					}
				}
			}
		}
	}
	else{
		if (second > third) {
			if (third > fourth) {
				if (fourth > fifth) {
					max = second;
				}
				else if (second > fifth) {
					max = second;
				}
				else {
					max = fifth;
				}
			}
			else{
				if (second > fourth) {
					if (fourth > fifth) {
						max = second;
					}
					else if (second > fifth) {
						max = second;
					}
					else {
						max = fifth;
					}
				}
				else {
					if (fourth > fifth) {
						max = fourth;
					}
					else {
						max = fifth;
					}
				}
			}
		}
		else {
			if (third > fourth) {
				if (fourth > fifth) {
					max = third;
				}
				else if (third > fifth) {
					max = third;
				}
				else {
					max = fifth;
				}
			}
			else{
				if (fourth > fifth) {
					max = fourth;
				}
				else {
					max = fifth;
				}
			}
		}
	}

	console.log(max);
}


