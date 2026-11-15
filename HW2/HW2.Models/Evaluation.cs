namespace HW2.HW2.Models;

public class Evaluation
{
    public Guid Id { get; }
    public Guid StudentId { get; }
    public Guid CriteriaId { get; }
    public Mark Mark { get; private set; }

    public Evaluation(Guid id, Guid studentId, Criteria criteria, Mark mark)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty");
        }

        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("StudentId cannot be empty");
        }

        if (criteria == null)
        {
            throw new ArgumentException("Criteria cannot be null");
        }
        if (mark == null)
        {
            throw new ArgumentException("Mark cannot be null");
        }
        criteria.EnsureScoreAllowed(mark);

        Id = id;
        StudentId = studentId;
        CriteriaId = criteria.Id;
        Mark = mark;
    }

    public void ChangeMark(Mark mark, Criteria criteria)
    {
        if (mark == null)
        {
            throw new ArgumentException("Mark cannot be null");
        }
        if (criteria == null)
        {
            throw new ArgumentException("Criteria cannot be null");
        }

        if (criteria.Id != CriteriaId)
        {
            throw new ArgumentException("Criteria does not match this evaluation");
        }

        criteria.EnsureScoreAllowed(mark);
        Mark = mark;
    }
}