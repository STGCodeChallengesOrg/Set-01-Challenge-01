#!/usr/bin/env ruby
# STG Challenge : Sorting
# Author: Ray Hunter ray.hunter@stgconsulting.com


# method to validate the input
def validate_input(list)

  list.each { |i|
    if /[a-zA-Z]+\d+/ !~ i
      return false
    end
  }

  true
end

# Get the input and clean it up
input = $stdin.read.gsub(/\n/, '')

# split the input into a list
list = input.split(/[, ]+/)

if validate_input(list)
  # sort the list handling the integer values first and then the alpha values second
  sorted = list.sort_by { |item| item.split(/(\d+)/).map { |e| [e.to_i, e] } }

  # print the output
  puts "Input:\t%s\n" % input
  puts "Output:\t%s\n" % sorted.join(' ')
else
  # input is invalid
  puts 'Input is invalid...'
end
