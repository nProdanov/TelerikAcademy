//
//  ViewController.swift
//  Calculator
//
//  Created by Nikolay Prodanow on 3/14/17.
//  Copyright © 2017 Nikolay Prodanow. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    private var userIsInTheMiddleOfTyping = false
    
    private var brain = CalculatorBrain()
    
    private var displayValue: Double{
        get{
            return Double(display.text!)!
        }
        set{
            display.text = String(newValue)
        }
    }
    
    @IBOutlet weak var display: UILabel!
    
    @IBAction func touchDigit(_ sender: UIButton) {
        let digit = sender.currentTitle!
        
        if userIsInTheMiddleOfTyping {
            display.text! += digit
        }
        else{
            display.text! = digit
            userIsInTheMiddleOfTyping = true
        }
    }
    
    @IBAction func performAction(_ sender: UIButton) {
        if userIsInTheMiddleOfTyping {
            brain.setOperand(displayValue)
            userIsInTheMiddleOfTyping = false
        }
        
        if let mathematicalSymbol = sender.currentTitle {
            brain.performOperation(mathematicalSymbol)
        }
        
        if let result = brain.result {
            displayValue = result
        }
    }
}

