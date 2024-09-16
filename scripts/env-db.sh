#!/bin/bash

read -p "Enter Oracle username: " MM_ORACLE_USERNAME
read -p "Enter Oracle password: " -s MM_ORACLE_PASSWORD

echo ""
echo "Setting environment variables"
export MM_ORACLE_USERNAME
export MM_ORACLE_PASSWORD
export MM_ORACLE_SOURCE="198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca"
