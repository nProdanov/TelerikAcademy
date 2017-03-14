//
//  CalculatorBrain.swift
//  Calculator
//
//  Created by Nikolay Prodanow on 3/14/17.
//  Copyright © 2017 Nikolay Prodanow. All rights reserved.
//

import Foundation

struct CalculatorBrain{
    
    private var accumulator: Double?
    
    private var operations: Dictionary<String, Operation> = [
        "π" : Operation.constant(M_PI),
        "e" : Operation.constant(M_E),
        "√" : Operation.unary(sqrt),
        "cos" : Operation.unary(cos),
        "=" : Operation.equals,
        "+" : Operation.binary(+),
        "-" : Operation.binary(-),
        "÷" : Operation.binary(/),
        "×" : Operation.binary(*)
    ]
    
    private var pendingBinaryOperation: PendingBinaryOperation?
    
    mutating func performOperation(_ symbol: String){
        if let operation = operations[symbol] {
            switch operation {
            case .constant(let value):
                accumulator = value
            case .unary(let function):
                if accumulator != nil {
                    accumulator = function(accumulator!)
                }
            case .binary(let function):
                if accumulator != nil {
                    pendingBinaryOperation = PendingBinaryOperation(function: function, firstOperand: accumulator!)
                    accumulator = nil
                }
            case .equals:
                performPendingBinaryOperation()
            }
        }
    }
    
    private mutating func performPendingBinaryOperation()
    {
        if pendingBinaryOperation != nil && accumulator != nil {
            accumulator = pendingBinaryOperation!.perform(with: accumulator!)
            pendingBinaryOperation = nil
        }
    }
    
    mutating func setOperand(_ operand: Double){
        accumulator = operand
    }
    
    var result: Double? {
        get{
            return accumulator
        }
    }
    
    private struct PendingBinaryOperation{
        let function: (Double, Double) -> Double
        let firstOperand: Double
        
        func perform(with secondOperand: Double) -> Double {
            return function(firstOperand, secondOperand)
        }
    }
    
    private enum Operation {
        case unary((Double) -> Double)
        case binary((Double, Double) -> Double)
        case constant(Double)
        case equals
    }
}
