

resource "aws_s3_bucket_acl" "acl" {
    bucket = var.nome #usar a variável que vc criou
    acl = "private"
    depends_on = [aws_s3_bucket.this] #preciso ver como vai ficar aqui
}

resource "aws_s3_bucket_public_access_block" "bucket_public_access_block" {
    bucket = var.nome #usar a variável que vc criou
    ignore_public_acls = true
    block_public_acls = true
    block_public_policy = true
    restrict_public_buckets = true
    depends_on = [aws_s3_bucket.this] #preciso ver como vai ficar aqui
}

#AQUI TODA A PARTE DESDE A LIN 36 ATÉ LN 81 DA FOLHETERIA

resource "aws_s3_bucket_lifecycle_configuration" "lifecycle" {
    bucket = var.nome #usar a variável que vc criou
    rule {
        status = "Enabled"
        id = "remove_old_files"

        expiration {
            days = 1
        }
    }

    depends_on = [aws_s3_bucket.this] #preciso ver como vai ficar aqui
}

resource "aws_s3_bucket_policy" "policy" {
    bucket = var.nome #usar a variável que vc criou
    policy = data.aws_iam_policy_document.bucket_policy.json
    depends_on = [aws_s3_bucket.this] #preciso ver como vai ficar aqui
}
