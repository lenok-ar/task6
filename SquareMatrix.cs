namespace OverLoad
{
  interface IPrototype<SquareMatrix>
  {
    SquareMatrix Clone();
  }

  internal class SquareMatrix : IEquatable<SquareMatrix>, IComparable<SquareMatrix>, IPrototype<SquareMatrix>
  {
    double[,] matrix = new double[3, 3];

    public void EnteringNumber()
    {
      var rand = new Random();

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          matrix[row, col] = rand.Next(-10, 10);
        }
      }
    }

    public static SquareMatrix operator +(SquareMatrix left, SquareMatrix right)
    {
      SquareMatrix result = new SquareMatrix();

      for (int row = 0; row < left.matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < left.matrix.GetLength(1); ++col)
        {
          result.matrix[row, col] = left.matrix[row, col] + right.matrix[row, col];
        }
      }

      return result;
    }

    public static SquareMatrix operator *(SquareMatrix left, SquareMatrix right)
    {
      SquareMatrix result = new SquareMatrix();

      for (int row = 0; row < left.matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < left.matrix.GetLength(1); ++col)
        {
          result.matrix[row, col] = left.matrix[row, col] * right.matrix[row, col];
        }
      }

      return result;
    }

    private double CalculateNormMatrix()
    {
      double norm_matrix = 0;

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          norm_matrix += Math.Pow(matrix[row, col], 2);
        }
      }

      return Math.Sqrt(norm_matrix);
    }

    public static bool operator >(SquareMatrix left, SquareMatrix right)
    {
      return left.CalculateNormMatrix() > right.CalculateNormMatrix();

    }

    public static bool operator <(SquareMatrix left, SquareMatrix right)
    {
      return left.CalculateNormMatrix() < right.CalculateNormMatrix();
    }

    public static bool operator >=(SquareMatrix left, SquareMatrix right)
    {
      return left.CalculateNormMatrix() >= right.CalculateNormMatrix();

    }

    public static bool operator <=(SquareMatrix left, SquareMatrix right)
    {
      return left.CalculateNormMatrix() <= right.CalculateNormMatrix();
    }

    public static bool operator ==(SquareMatrix left, SquareMatrix right)
    {
      if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
      {
        return true;
      }

      if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
      {
        return false;
      }

      for (int row = 0; row < left.matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < left.matrix.GetLength(1); ++col)
        {
          if (left.matrix[row, col] != right.matrix[row, col])
          {
            return false;
          }
        }
      }

      return true;
    }

    public static bool operator !=(SquareMatrix left, SquareMatrix right)
    {
      return !(left == right);
    }

    public static bool operator true(SquareMatrix matrix)
    {
      for (int row = 0; row < matrix.matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.matrix.GetLength(1); ++col)
        {
          if (matrix.matrix[row, col] <= 0)
          {
            return false;
          }
        }
      }

      return true;
    }

    public static bool operator false(SquareMatrix matrix)
    {
      for (int row = 0; row < matrix.matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.matrix.GetLength(1); ++col)
        {
          if (matrix.matrix[row, col] <= 0)
          {
            return true;
          }
        }
      }

      return false;
    }

    public double Determinant()
    {
      double result = 0;

      result = matrix[0, 0] * matrix[1, 1] * matrix[2, 2];
      result += matrix[0, 1] * matrix[1, 2] * matrix[2, 0];
      result += matrix[0, 2] * matrix[1, 0] * matrix[2, 1];
      result -= matrix[0, 2] * matrix[1, 1] * matrix[2, 0];
      result -= matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
      result -= matrix[0, 1] * matrix[1, 0] * matrix[2, 2];

      return result;
    }

    public SquareMatrix InverseMatrix()
    {
      SquareMatrix inverse = new SquareMatrix();

      double determinant = Determinant();

      inverse.matrix[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / determinant;
      inverse.matrix[0, 1] = -(matrix[0, 1] * matrix[2, 2] - matrix[0, 2] * matrix[2, 1]) / determinant;
      inverse.matrix[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / determinant;

      inverse.matrix[1, 0] = -(matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) / determinant;
      inverse.matrix[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / determinant;
      inverse.matrix[1, 2] = -(matrix[0, 0] * matrix[1, 2] - matrix[0, 2] * matrix[1, 0]) / determinant;

      inverse.matrix[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / determinant;
      inverse.matrix[2, 1] = -(matrix[0, 0] * matrix[2, 1] - matrix[0, 1] * matrix[2, 0]) / determinant;
      inverse.matrix[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / determinant;

      return inverse;
    }

    public override string ToString()
    {
      string exportMatrix = "";

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          exportMatrix += matrix[row, col] + "\t";
        }

        exportMatrix += "\n";
      }

      return exportMatrix;
    }

    public int CompareTo(SquareMatrix? secondMatrix)
    {
      if (secondMatrix == null)
      {
        return 1;
      }

      double normThisMatrix = this.CalculateNormMatrix();
      double normSecondMatrix = secondMatrix.CalculateNormMatrix();

      return normThisMatrix.CompareTo(normSecondMatrix);
    }

    public bool Equals(SquareMatrix? secondMatrix)
    {
      if (secondMatrix == null)
      {
        return false;
      }

      if (ReferenceEquals(this, secondMatrix))
      {
        return true;
      }

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          if (matrix[row, col] != secondMatrix.matrix[row, col])
          {
            return false;
          }
        }
      }

      return true;
    }

    public override bool Equals(object? isMatrix)
    {
      return Equals(isMatrix as SquareMatrix);
    }

    public override int GetHashCode()
    {
      int hash = 5;

      for (int row = 0; row <= matrix.GetLength(0); ++row)
      {
        for (int col = 0; col <= matrix.GetLength(1); ++col)
        {
          hash = hash * 10 + matrix[row, col].GetHashCode();
        }
      }

      return hash;
    }

    public SquareMatrix Clone()
    {
      SquareMatrix clonedMatrix = new SquareMatrix();

      clonedMatrix.matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          clonedMatrix.matrix[row, col] = matrix[row, col];
        }
      }

      return clonedMatrix;
    }

    public SquareMatrix Transposition()
    {
      SquareMatrix transpositionMatrix = new SquareMatrix();

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          transpositionMatrix.matrix[row, col] = matrix[col, row];
        }
      }

      return transpositionMatrix;
    }

    public double TraceMatrix()
    {
      double traceMatrix = 0;

      for (int row = 0; row < matrix.GetLength(0); ++row)
      {
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
          if (row == col)
          {
            traceMatrix += matrix[row, col];
          }
        }
      }

      return traceMatrix;
    }

    public SquareMatrix Diagonalization()
    {
      SquareMatrix diagonalizedMatrix = this.Clone();

      diagonalizedMatrix.matrix[1, 1] = (diagonalizedMatrix.matrix[0, 0] * diagonalizedMatrix.matrix[1, 1]) - (diagonalizedMatrix.matrix[0, 1] * diagonalizedMatrix.matrix[1, 0]);
      diagonalizedMatrix.matrix[1, 2] = (diagonalizedMatrix.matrix[0, 0] * diagonalizedMatrix.matrix[1, 2]) - (diagonalizedMatrix.matrix[0, 2] * diagonalizedMatrix.matrix[1, 0]);
      diagonalizedMatrix.matrix[2, 1] = (diagonalizedMatrix.matrix[0, 0] * diagonalizedMatrix.matrix[2, 1]) - (diagonalizedMatrix.matrix[0, 1] * diagonalizedMatrix.matrix[2, 0]);
      diagonalizedMatrix.matrix[2, 2] = (diagonalizedMatrix.matrix[0, 0] * diagonalizedMatrix.matrix[2, 2]) - (diagonalizedMatrix.matrix[0, 2] * diagonalizedMatrix.matrix[2, 0]);
      diagonalizedMatrix.matrix[1, 0] = 0;
      diagonalizedMatrix.matrix[2, 0] = 0;

      diagonalizedMatrix.matrix[0, 2] = (diagonalizedMatrix.matrix[1, 1] * diagonalizedMatrix.matrix[0, 2]) - (diagonalizedMatrix.matrix[0, 1] * diagonalizedMatrix.matrix[1, 2]);
      diagonalizedMatrix.matrix[2, 2] = (diagonalizedMatrix.matrix[1, 1] * diagonalizedMatrix.matrix[2, 2]) - (diagonalizedMatrix.matrix[1, 2] * diagonalizedMatrix.matrix[2, 1]);
      diagonalizedMatrix.matrix[0, 1] = 0;
      diagonalizedMatrix.matrix[2, 1] = 0;

      diagonalizedMatrix.matrix[0, 2] = 0;
      diagonalizedMatrix.matrix[1, 2] = 0;

      return diagonalizedMatrix;
    }

    public delegate SquareMatrix DiagonalizationDelegate();

    public SquareMatrix DiagonalizeWithDelegate()
    {
      DiagonalizationDelegate diagonalizationMethod = delegate ()
      {
        return this.Diagonalization();
      };

      return diagonalizationMethod();
    }
  }
}